using TestTask.Service.Helpers;
using TMPro;
using UnityEngine;

namespace TestTask.UI.Gameplay.Timer
{
    public class TimerUiView : MonoBehaviour
    {
        private const int LittleTimeThreshold = 15;
        
        [SerializeField] private TextMeshProUGUI _timerText;
        
        private readonly Color _originalColor = Color.black;
        private readonly Color _littleTimeLeftColor = Color.red;

        public void SetTimerText(int secondsLeft)
        {
            _timerText.text = TimeFormatHelper.FormatTime(secondsLeft);
            SetTimerTextColor(secondsLeft);
        }

        private void SetTimerTextColor(int secondsLeft)
            => _timerText.color = secondsLeft <= LittleTimeThreshold ? _littleTimeLeftColor : _originalColor;
    }
}