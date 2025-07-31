using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestTask.DataLayer.Databases.Sounds
{
    [CreateAssetMenu(fileName = "SoundsDatabase", menuName = "Data/Sounds Database")]
    public class SoundsDatabase : ScriptableObject
    {
        [SerializeField] private List<SoundsDatabaseEntry> _sounds = new ();
        
        private Dictionary<string, SoundsDatabaseEntry> _soundsDictionary;
        public Dictionary<string, SoundsDatabaseEntry> SoundsDictionary 
            => _soundsDictionary ??= _sounds.ToDictionary(sde => sde.Name);
    }
}