using System;
using TestTask.DataLayer;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TestTask.Gameplay.Entities.Spawning
{
    public class EntitySpawner
    {
        // No DI to make prototype faster, simulate by singleton
        private static EntitySpawner _instance;
        public static EntitySpawner Instance => _instance ??= new EntitySpawner();

        public TEntity SpawnEntity<TEntity>(string key, Vector3 position, Quaternion rotation, 
            Action<TEntity> onSpawn = null)
            where TEntity : BaseEntity
        {
            // TODO: pooling? seems to be not required due to small amount of entities
            var prefab = GameDataProvider.Instance.EntityPrefabDatabase.PrefabsDictionary[key];
            var instance = Object.Instantiate(prefab, position, rotation) as TEntity;
            onSpawn?.Invoke(instance);
            return instance;
        }
    }
}