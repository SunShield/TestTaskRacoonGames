using TestTask.Gameplay.Entities.Visuals;
using UnityEngine;

namespace TestTask.Gameplay.Entities
{
    public class EntityWithNumber : BaseEntity
    {
        [SerializeField] private EntityWithNumberVisuals _visuals;
        
        private int _power;

        public void SetPower(int power)
        {
            _power = power;
            UpdateVisuals();
        }

        private void UpdateVisuals() =>  _visuals.Setup(_power);
    }
}