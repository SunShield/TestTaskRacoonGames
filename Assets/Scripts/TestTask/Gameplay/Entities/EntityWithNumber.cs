using TestTask.Gameplay.Entities.Visuals;
using TestTask.Gameplay.Merging;
using TestTask.Sounds;
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
            if (!collision.gameObject.TryGetComponent(out EntityWithNumber another)) return;
            
            var mergeResult = MergeManager.Instance.RegisterMergeAttempt(this, another);
            SoundManager.Instance.PlaySfx(!mergeResult 
                ? Constants.Sounds.CubeHit 
                : Constants.Sounds.Merge);
        }

        public override bool CanMergeWith(BaseEntity other)
        {
            var otherTyped = other as EntityWithNumber;
            if (otherTyped == null) return false;
            return Power == otherTyped.Power;
        }
    }
}