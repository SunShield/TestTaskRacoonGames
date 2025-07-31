using TestTask.DataLayer;
using TestTask.Gameplay.Entities;
using TestTask.Gameplay.Launching;
using TestTask.Service.Classes;
using UnityEngine;

namespace TestTask.Gameplay.Merging
{
    public class MergeManager : MonoSingleton<MergeManager>
    {
        private float MergeVelocityThreshold => GameDataProvider.Instance.MergeSettings.MergeVelocityThreshold;
        private float PostMergePushStrength => GameDataProvider.Instance.MergeSettings.PostMergePushStrength;
        private const float HorizontalComponentMultiplier = 0.25f;
        
        public void RegisterMergeAttempt(EntityWithNumber entity, EntityWithNumber another)
        {
            if (!EntityLauncher.Instance.IsLaunching) return;
            if (entity.Power != another.Power) return;
            if (entity.Rigidbody.linearVelocity.magnitude < MergeVelocityThreshold) return;
            
            entity.Rigidbody.linearVelocity = Vector3.zero;
            Destroy(another.gameObject);
            entity.SetPower(entity.Power + 1);
            
            DoPostMergeJump(entity);
        }

        private void DoPostMergeJump(EntityWithNumber entity)
        {
            Vector3 randomDir = entity.transform.up + 
                                Random.insideUnitCircle.x * entity.transform.right + 
                                Random.insideUnitCircle.y * entity.transform.forward;

            var normalized = randomDir.normalized;
            entity.Rigidbody.AddForce(new Vector3(
                    normalized.x * PostMergePushStrength * HorizontalComponentMultiplier, 
                    normalized.y * PostMergePushStrength, 
                    normalized.z * PostMergePushStrength * HorizontalComponentMultiplier), 
                ForceMode.Impulse);
        }
    }
}