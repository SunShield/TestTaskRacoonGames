using System.Collections.Generic;
using System.Linq;
using TestTask.Gameplay.Entities;
using UnityEngine;

namespace TestTask.DataLayer.Databases.Entities
{
    [CreateAssetMenu(fileName = "PrefabDatabase", menuName = "Data/Entity Prefabs Database")]
    public class EntityPrefabDatabase : ScriptableObject
    {
        [SerializeField] private List<EntityDatabaseEntry> _entities;
        
        private Dictionary<string, BaseEntity> _prefabsDictionary;
        public Dictionary<string, BaseEntity> PrefabsDictionary => 
            _prefabsDictionary ??= _entities.ToDictionary(p => p.Name, p => p.Prefab);
    }
}