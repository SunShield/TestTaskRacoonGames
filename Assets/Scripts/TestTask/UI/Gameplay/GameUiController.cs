using TestTask.UI.Base.Elements;
using TestTask.UI.Gameplay.Score;
using TestTask.UI.Gameplay.Timer;
using UnityEngine;

namespace TestTask.UI.Gameplay
{
    public class GameUiController : UiElement
    {
        [SerializeField] private ScoreUiController _scoreUiController;
        [SerializeField] private TimerUiController _gameUiController;
        
        private void OnEnable()
        {
            _scoreUiController.Initialize();
            _gameUiController.Initialize();
        }
    }
}