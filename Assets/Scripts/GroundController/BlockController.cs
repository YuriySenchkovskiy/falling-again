using UnityEngine;

namespace GroundController
{
    public class BlockController : MonoBehaviour
    {
        [SerializeField] private float _verticalSpeed;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private void FixedUpdate()
        {
            if (_rigidbody.velocity.y < _verticalSpeed)
            {
                var velocity = new Vector2(_rigidbody.velocity.x, _verticalSpeed);
                _rigidbody.velocity = velocity;
            }
        }
    }
}