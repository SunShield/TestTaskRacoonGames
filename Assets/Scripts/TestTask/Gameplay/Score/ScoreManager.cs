using TestTask.Service.Classes;
using UnityEngine;

namespace TestTask.Gameplay.Score
{
    public class ScoreManager : MonoSingleton<ScoreManager>
    {
        public int GetScoreByPower(int power)
        {
            return (int)Mathf.Pow(2, power);
        }
    }
}