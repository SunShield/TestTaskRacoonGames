using UnityEngine;

namespace TestTask.DataLayer.Settings
{
    [CreateAssetMenu(fileName = "MergeSettings", menuName = "Data/Settings/MergeSettings", order = 1)]
    public class MergeSettings : ScriptableObject
    {
        public float MergeVelocityThreshold = 5f;
        public float PostMergePushStrength = 6f;
    }
}