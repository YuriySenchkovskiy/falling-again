using System;
using UnityEngine;
using Utils;
using Utils.Disposable;

namespace ColliderBased
{
    public class EnterTriggerAction : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private EnterEventComponent _action; 
        [SerializeField] private Transform _targetTransform;
        
        private static Action<Transform> _triggerTransformDetected;
        private static Action _triggerDetected;
        
        public static IDisposable Subscribe(Action<Transform> call)
        {
            _triggerTransformDetected += call;
            return new ActionDisposable(() => _triggerTransformDetected -= call);
        }
        
        public static IDisposable Subscribe(Action call)
        {
            _triggerDetected += call;
            return new ActionDisposable(() => _triggerDetected -= call);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.GetLayerStatus(_layer))
            {
                return;
            }

            _action?.Invoke(other.gameObject);
            _triggerTransformDetected?.Invoke(_targetTransform);
            _triggerDetected?.Invoke();
        }
    }
}