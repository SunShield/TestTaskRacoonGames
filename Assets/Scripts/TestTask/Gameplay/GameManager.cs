using TestTask.Gameplay.Launching;
using TestTask.Gameplay.Levels;
using TestTask.Gameplay.Score;
using TestTask.Service.Classes;
using TestTask.UI.Base;
using TestTask.UI.Gameplay;
using UnityEngine;

namespace TestTask.Gameplay
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private void Start()
        {
            StartGame();
        }
        
        public async void StartGame()
        {
            LevelManager.Instance.LoadLevel(Constants.Levels.TestLevel);
            
            await LevelManager.Instance.StartLevel();
            LevelManager.Instance.OnTimePassed += LoseGame;

            UiManager.Instance.ShowUiElement<GameUiController>();
            ScoreManager.Instance.Initialize();
            EntityLauncher.Instance.StartLaunching();
        }

        public void LoseGame()
        {
            // nothing here now, wasnt requested in test task
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}