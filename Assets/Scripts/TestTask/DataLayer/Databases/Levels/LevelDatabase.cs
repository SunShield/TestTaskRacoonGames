using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestTask.DataLayer.Databases.Levels
{
    [CreateAssetMenu(fileName = "LevelDatabase", menuName = "Data/Level Database")]
    public class LevelDatabase : ScriptableObject
    {
        [SerializeField] private List<LevelData> _datas;
        private Dictionary<string, LevelData> _levelsDictionary;
        public Dictionary<string, LevelData> LevelsDictionary 
            => _levelsDictionary ??= _datas.ToDictionary(ld => ld.Name);
    }
}