using Cysharp.Threading.Tasks;
using TestTask.Gameplay.Levels.Events;
using UnityEngine;

namespace TestTask.Gameplay.Levels
{
    public class Level : MonoBehaviour
    {
        // better approach would be to add those to LevelData through Odin'n polymirphous serialization
        // but for now, it's OK
        [SerializeField] private LevelEvents _levelEvents;

        public async UniTask StartLevel()
        {
            await _levelEvents.OnLevelStarted();
        }
    }
}