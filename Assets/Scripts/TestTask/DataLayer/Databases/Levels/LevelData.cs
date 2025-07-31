using System;
using TestTask.Gameplay.Levels;

namespace TestTask.DataLayer.Databases.Levels
{
    [Serializable]
    public class LevelData
    {
        public string Name;
        public Level Prefab;
        public string LaunchedEntityKey;
        public int SecondsToComplete;
        public string MusicKey;
        // possibly, ScoreGoal
    }
}