using UnityEngine;

namespace TestTask.Gameplay.Entities
{
    public abstract class BaseEntity : MonoBehaviour
    {
        [field: SerializeField] public Collider Collider { get; set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    }
}