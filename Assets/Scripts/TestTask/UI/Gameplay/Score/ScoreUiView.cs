using TMPro;
using UnityEngine;

namespace TestTask.UI.Gameplay.Score
{
    public class ScoreUiView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}