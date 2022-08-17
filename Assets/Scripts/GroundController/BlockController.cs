using System;
using UnityEngine;

namespace GroundController
{
    public class BlockController : MonoBehaviour
    {
        [SerializeField] private float _startVerticalSpeed;
        [SerializeField] private Rigidbody2D _rigidbody;

        private void Start()
        {
            var velocity = new Vector2(_rigidbody.velocity.x, _startVerticalSpeed);
            _rigidbody.velocity = velocity;
        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(_rigidbody.velocity.y) > Mathf.Abs(_startVerticalSpeed))
            {
                var velocity = new Vector2(_rigidbody.velocity.x, _startVerticalSpeed);
                _rigidbody.velocity = velocity;
            }
        }
    }
}