using UnityEngine;

namespace TestTask.Service.Classes
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        [SerializeField] private bool _dontDestroyOnLoad = false;

        private static T _instance;
        private static bool _quitting;

        public static T Instance
        {
            get
            {
                if (_quitting) return null;
                if (!ProcessInstance()) return null;

                return _instance;
            }
        }

        private void Awake()
        {
            if (!_dontDestroyOnLoad) return;
            ProcessInstance();
        }

        private static bool ProcessInstance()
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>(FindObjectsInactive.Include);

                if (_instance == null)
                {
                    Debug.LogError($"[MonoSingleton] No {typeof(T).Name} found in scene.");
                    return false;
                }

                if (_instance._dontDestroyOnLoad) DontDestroyOnLoad(_instance.gameObject);
            }

            return true;
        }

        private void OnDestroy() => _instance = null;
        protected virtual void OnApplicationQuit() => _quitting = true;
    }
}