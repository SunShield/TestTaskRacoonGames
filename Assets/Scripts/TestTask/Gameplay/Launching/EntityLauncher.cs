using System;
using TestTask.DataLayer;
using TestTask.Gameplay.Entities;
using TestTask.Gameplay.Entities.Spawning;
using TestTask.Gameplay.Levels;
using TestTask.Service.Classes;
using TestTask.Sounds;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestTask.Gameplay.Launching
{
    public class EntityLauncher : MonoSingleton<EntityLauncher>
    {
        private const float ShiftY = 0.01f;
        
        private Bounds _cubeSpawnZone;
        private string _launchedEntityKey;
        private EntityWithNumber _currentEntityToLaunch;
        private float _launchDelayTimer;
        private Camera _camera;
        private float _fingerPos;
        
        public bool IsLaunching { get; private set; }
        private BaseEntity LaunchedEntity => 
            GameDataProvider.Instance.EntityPrefabDatabase.PrefabsDictionary[_launchedEntityKey];
        private float LaunchForce => GameDataProvider.Instance.LaunchSettings.LaunchForce;
        private float LaunchDelay => GameDataProvider.Instance.LaunchSettings.LaunchDelay;
        private bool CooldowningLaunch => _launchDelayTimer > 0f;

        public void Init(Level level, string launchedEntityKey)
        {
            _launchedEntityKey = launchedEntityKey;
            _cubeSpawnZone = level.CubeSpawnZone.bounds;
            _camera = Camera.main;
        }

        public void StartLaunching()
        {
            IsLaunching = true;
        }

        private async void PrepareLaunchableEntity()
        {
            // assuming entity launched is always at least EntityWithNumber
            _currentEntityToLaunch = EntitySpawner.Instance.SpawnEntity<EntityWithNumber>(
                _launchedEntityKey, GetRandomSpawnPoint(), Quaternion.identity);
            var randomPower = GetRandomPower();
            _currentEntityToLaunch.SetPower(randomPower);
        }

        private Vector3 GetRandomSpawnPoint()
        {
            var entityCenterHeight = LaunchedEntity.Collider.bounds.size.y / 2;
            
            var randomZoneX = _cubeSpawnZone.size.x / 2;
            var randomZoneZ = _cubeSpawnZone.size.z / 2;
            
            var randomX = _cubeSpawnZone.center.x + Random.Range(-randomZoneX, randomZoneX);
            var randomZ = _cubeSpawnZone.center.z + Random.Range(-randomZoneZ, randomZoneZ);
            
            return new Vector3(randomX, entityCenterHeight + ShiftY, randomZ);
        }

        //  maybe later do it per-level, but for now generalized is OK 
        private int GetRandomPower()
        {
            var launchSettings = GameDataProvider.Instance.LaunchSettings;
            var random = Random.Range(0, 1f);
            for (int i = 0; i < launchSettings.PowerWeights.Count; i++)
            {
                var weight = launchSettings.PowerWeights[i];
                if (random < weight) return i + 1;
            }
            
            return launchSettings.PowerWeights.Count;
        }
        
        private void Update()
        {
            if (CooldowningLaunch)
            {
                AdvanceLaunchTimer();
                if (CooldowningLaunch) return;
            }
            
            if (Input.touchCount == 0) return;

            ProcessTouch();
        }

        private void ProcessTouch()
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    PrepareLaunchableEntity();
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    MoveCubeWithFinger(touch);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    TryLaunch();
                    break;
            }
        }

        private void TryLaunch()
        {
            if (CooldowningLaunch) return;
            
            _launchDelayTimer = LaunchDelay;
            Launch();
        }

        private void Launch()
        {
            _currentEntityToLaunch.Rigidbody.AddForce(Vector3.forward * LaunchForce, ForceMode.Impulse);
            SoundManager.Instance.PlaySfx(Constants.Sounds.CubeLaunch);
        }
        
        private void AdvanceLaunchTimer() => _launchDelayTimer = Mathf.Max(_launchDelayTimer- Time.deltaTime, 0f);
        
        private void MoveCubeWithFinger(Touch touch)
        {
            if (_currentEntityToLaunch == null)
                return;

            var screenPoint = new Vector3(touch.position.x, touch.position.y, 
                _camera.WorldToScreenPoint(_currentEntityToLaunch.transform.position).z);
            var worldPoint = _camera.ScreenToWorldPoint(screenPoint);
            var pos = _currentEntityToLaunch.transform.position;
            _currentEntityToLaunch.transform.position = new Vector3(worldPoint.x, pos.y, pos.z);
        }
    }
}