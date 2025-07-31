using TestTask.Gameplay.Levels;
using TestTask.Service.Classes;

namespace TestTask.Gameplay
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private void Start()
        {
            StartGame();
        }
        
        public void StartGame()
        {
            LevelManager.Instance.LoadLevel(Constants.Levels.TestLevel);
            LevelManager.Instance.StartLevel();
        }

        public void RestartGame()
        {
            
        }
    }
}