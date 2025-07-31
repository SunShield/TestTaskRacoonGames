using System;
using TestTask.Gameplay.Entities;

namespace TestTask.DataLayer.Databases.Entities
{
    [Serializable]
    public class EntityDatabaseEntry
    {
        public string Name;
        public BaseEntity Prefab;
    }
}