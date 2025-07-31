using TestTask.UI.Base.Elements;
using TestTask.UI.Gameplay.Score;
using UnityEngine;

namespace TestTask.UI.Gameplay
{
    public class GameUiController : UiElement
    {
        [SerializeField] private ScoreUiController _scoreUiController;
        
        private void OnEnable()
        {
            _scoreUiController.Initialize();
        }
    }
}