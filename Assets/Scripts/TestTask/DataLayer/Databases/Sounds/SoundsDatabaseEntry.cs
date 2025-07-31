using System;
using UnityEngine;

namespace TestTask.DataLayer.Databases.Sounds
{
    [Serializable]
    public class SoundsDatabaseEntry
    {
        public string Name;
        public float Volume;
        public AudioClip Clip;
    }
}