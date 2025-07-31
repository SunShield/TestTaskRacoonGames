using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using TestTask.Gameplay.Entities;
using TestTask.Gameplay.Entities.Spawning;
using UnityEngine;

namespace TestTask.Gameplay.Levels.Events
{
    /// <summary>
    /// This can be used to introduce some interesting behaviour of a level.
    /// For the prototype impl, we will use just "spawn start cubes"
    ///
    /// The best approach here is to use Odin and create a serialized list of actions like SpawnCube or whatever
    /// </summary>
    public class LevelEvents : MonoBehaviour
    {
        [SerializeField] private BoxCollider _spawnZone;
        [SerializeField] private GameObject _invisibleWall;
        [SerializeField, Range(0, 2)] private int _startingCubesAmountMin;
        [SerializeField, Range(2, 5)] private int _startingCubesAmountMax;
        
        public async UniTask OnLevelStarted()
        {
            var cubesAmount = Random.Range(_startingCubesAmountMin, _startingCubesAmountMax + 1);
            var cubes = new List<EntityWithNumber>();
            for (int i = 0; i < cubesAmount; i++)
            {
                var randomPoint = _spawnZone.bounds.center ;
                var cube = EntitySpawner.Instance.SpawnEntity<EntityWithNumber>(
                    Constants.Entities.BasicCube, 
                    GetRandomSpawnPoint(), 
                    GetRandomRotation());
                cube.SetPower(GetRandomPower());
                cubes.Add(cube);
            }
            
            await UniTask.WaitWhile(() => cubes.Any(c => !CheckCubeStopped(c)));
            _invisibleWall.SetActive(false);
        }

        private Vector3 GetRandomSpawnPoint()
        {
            var bounds = _spawnZone.bounds;
            
            var randomZoneX = bounds.size.x / 2;
            var randomZoneZ = bounds.size.z / 2;
            
            var randomX = bounds.center.x + Random.Range(-randomZoneX, randomZoneX);
            var randomZ = bounds.center.z + Random.Range(-randomZoneZ, randomZoneZ);
            
            return new Vector3(randomX, bounds.center.y, randomZ);
        }

        private Quaternion GetRandomRotation()
        {
            var x = Random.Range(-180, 180);
            var y = Random.Range(-180, 180);
            var z = Random.Range(-180, 180);
            return new Quaternion(x, y, z, 0);
        }

        private int GetRandomPower() => Random.Range(1, 4);

        private bool CheckCubeStopped(BaseEntity entity)
        {
            return entity.Rigidbody.linearVelocity.sqrMagnitude  < 0.01f &&
                   entity.Rigidbody.angularVelocity.sqrMagnitude < 0.01f;
        }
    }
}