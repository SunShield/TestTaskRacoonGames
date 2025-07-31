using System.Collections.Generic;
using UnityEngine;

namespace TestTask.DataLayer.Settings
{
    [CreateAssetMenu(fileName = "LaunchSettings", menuName = "Data/Settings/LaunchSettings")]
    public class LaunchSettings : ScriptableObject
    {
        [field: SerializeField] public float LaunchDelay { get; private set; } = 1.5f;
        [field: SerializeField] public float LaunchForce { get; private set; } = 15f;
        [field: SerializeField] public List<float> PowerWeights { get; private set; } 
    }
}