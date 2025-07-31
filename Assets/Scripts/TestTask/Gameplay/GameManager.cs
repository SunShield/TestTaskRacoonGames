using TestTask.Gameplay.Launching;
using TestTask.Gameplay.Levels;
using TestTask.Gameplay.Score;
using TestTask.Service.Classes;

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
            
            ScoreManager.Instance.Initialize();
            EntityLauncher.Instance.StartLaunching();
        }

        public void RestartGame()
        {
            
        }
    }
}