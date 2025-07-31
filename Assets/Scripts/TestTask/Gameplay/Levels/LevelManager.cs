using TestTask.DataLayer;
using TestTask.DataLayer.Databases.Levels;
using TestTask.Service.Classes;
using UnityEngine;

namespace TestTask.Gameplay.Levels
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        [SerializeField] private Transform _levelOrigin;
        
        public LevelData LevelData { get; private set; }
        public Level LevelInstance { get; private set; }
        
        public void LoadLevel(string levelName)
        {
            // using local db for tests; consider async is addressables will be used
            LevelData = GameDataProvider.Instance.LevelDatabase.LevelsDictionary[levelName];
            LevelInstance = Instantiate(LevelData.Prefab, _levelOrigin);
        }

        public async void StartLevel()
        {
            await LevelInstance.StartLevel();
        }
    }
}