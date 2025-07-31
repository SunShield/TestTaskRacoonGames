using UnityEngine;

namespace TestTask.Gameplay.Entities
{
    public abstract class BaseEntity : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    }
}