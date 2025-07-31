using System;
using TestTask.Gameplay.Entities;
using TestTask.Gameplay.Merging;
using TestTask.Service.Classes;
using UnityEngine;

namespace TestTask.Gameplay.Score
{
    public class ScoreManager : MonoSingleton<ScoreManager>
    {
        public int Score { get; private set; }
        
        public void Initialize()
        {
            MergeManager.Instance.OnEntityMerged += EntityMergedHandler;
        }
        
        private void EntityMergedHandler(EntityWithNumber entity, int score)
        {
            var scoreGained = GetScoreByPower(score);
            AddScore(scoreGained);
        }
        
        public int GetScoreByPower(int power) => (int)Mathf.Pow(2, power - 1);

        private void AddScore(int score)
        {
            Score += score;
            OnScoreChanged?.Invoke(Score);
        }
        
        public event Action<int> OnScoreChanged;
    }
}