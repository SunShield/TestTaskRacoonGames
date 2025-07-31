using TestTask.Gameplay.Entities.Visuals;
using TestTask.Gameplay.Merging;
using UnityEngine;

namespace TestTask.Gameplay.Entities
{
    public class EntityWithNumber : BaseEntity
    {
        [SerializeField] private EntityWithNumberVisuals _visuals;
        
        public int Power { get; private set; }

        public void SetPower(int power)
        {
            Power = power;
            UpdateVisuals();
        }

        private void UpdateVisuals() =>  _visuals.Setup(Power);

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent<EntityWithNumber>(out EntityWithNumber another)) return;
            
            MergeManager.Instance.RegisterMergeAttempt(this, another);
        }
    }
}