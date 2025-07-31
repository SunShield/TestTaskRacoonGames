using System.Collections.Generic;
using UnityEngine;

namespace TestTask.DataLayer.Databases
{
    [CreateAssetMenu(fileName = "ColorsDatabase", menuName = "Data/Colors Database")]
    public class ColorsDatabase : ScriptableObject
    {
        [field: SerializeField] public List<Color> Colors { get; private set; }
        
        public int Count => Colors.Count;
        public Color this[int index] => Colors[index];
    }
}

