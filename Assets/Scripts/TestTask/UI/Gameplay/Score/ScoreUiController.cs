using TestTask.Gameplay.Score;
using UnityEngine;

namespace TestTask.UI.Gameplay.Score
{
    public class ScoreUiController : MonoBehaviour
    {
        [SerializeField] private ScoreUiView _scoreUiView;

        public void Initialize()
        {
            ScoreManager.Instance.OnScoreChanged += ScoreChangedHandler;
            _scoreUiView.SetScore(0);
        }

        private void ScoreChangedHandler(int newScore)
        {
            _scoreUiView.SetScore(newScore);
        }

        private void OnDisable()
        {
            ScoreManager.Instance.OnScoreChanged -= ScoreChangedHandler;
        }
    }
}