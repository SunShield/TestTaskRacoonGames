using TestTask.DataLayer.Databases;
using TestTask.DataLayer.Databases.Entities;
using TestTask.DataLayer.Databases.Levels;
using TestTask.Service.Classes;
using UnityEngine;

namespace TestTask.DataLayer
{
    public class GameDataProvider : MonoSingleton<GameDataProvider>
    {
        [field: SerializeField] public EntityPrefabDatabase EntityPrefabDatabase { get; private set; }
        [field: SerializeField] public ColorsDatabase ColorsDatabase { get; private set; }
        [field: SerializeField] public LevelDatabase LevelDatabase { get; private set; }
    }
}