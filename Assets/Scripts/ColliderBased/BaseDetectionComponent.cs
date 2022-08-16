using System;
using UnityEngine;
using Utils;

namespace ColliderBased
{
    public abstract class BaseDetectionComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private EnterEventComponent _action;

        private void OnEnable()
        {
        }

        protected void DetectCollision(Collision2D other)
        {
            if (!other.gameObject.GetLayerStatus(_layer))
            {
                return;
            }

            _action?.Invoke(other.gameObject);
        }
        
        protected void DetectCollider(Collider2D other)
        {
            if (!other.gameObject.GetLayerStatus(_layer))
            {
                return;
            }

            _action?.Invoke(other.gameObject);
        }
    }
}