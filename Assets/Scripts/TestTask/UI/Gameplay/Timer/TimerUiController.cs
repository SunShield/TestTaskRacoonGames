using TestTask.Gameplay.Levels;
using UnityEngine;

namespace TestTask.UI.Gameplay.Timer
{
    public class TimerUiController : MonoBehaviour
    {
        [SerializeField] private TimerUiView _view;
        
        public void Initialize()
        {
            _view.SetTimerText(LevelManager.Instance.LevelData.SecondsToComplete);
            LevelManager.Instance.OnTimeChanged += TimeChangeHandler;
        }

        private void TimeChangeHandler(int timeLeft, int maxTime)
        {
            _view.SetTimerText(timeLeft);
        }

        private void OnDisable()
        {
            LevelManager.Instance.OnTimeChanged -= TimeChangeHandler;
        }
    }
}