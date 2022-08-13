using UnityEngine;

namespace ColliderBased
{
    public class EnterCollisionComponent : BaseDetectionComponent
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            base.DetectCollision(other);
        }
    }
}
