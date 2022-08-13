using UnityEngine;

namespace ColliderBased
{
    public class EnterTriggerComponent : BaseDetectionComponent
    {
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            base.DetectCollider(other);
        }
    }
}
