using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestTask.Init
{
    public class AppInitializer : MonoBehaviour
    {
        private async void Start()
        {
            await SceneManager.LoadSceneAsync(Constants.Scenes.GameScene);
        }
    }
}