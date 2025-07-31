using TestTask.DataLayer.Databases;
using TestTask.DataLayer.Databases.Entities;
using TestTask.DataLayer.Databases.Levels;
using TestTask.DataLayer.Databases.Sounds;
using TestTask.DataLayer.Databases.Ui;
using TestTask.DataLayer.Settings;
using TestTask.Service.Classes;
using UnityEngine;

namespace TestTask.DataLayer
{
    public class GameDataProvider : MonoSingleton<GameDataProvider>
    {
        [field: SerializeField] public EntityPrefabDatabase EntityPrefabDatabase { get; private set; }
        [field: SerializeField] public ColorsDatabase       ColorsDatabase       { get; private set; }
        [field: SerializeField] public LevelDatabase        LevelDatabase        { get; private set; }
        [field: SerializeField] public SoundsDatabase       SoundsDatabase       { get; private set; }
        [field: SerializeField] public UiElementsDatabase   UiElementsDatabase   { get; private set; }
        
        [field: SerializeField] public LaunchSettings LaunchSettings { get; private set; }
        [field: SerializeField] public MergeSettings  MergeSettings  { get; private set; }
    }
}