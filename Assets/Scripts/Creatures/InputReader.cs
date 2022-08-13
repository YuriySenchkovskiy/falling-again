using UnityEngine;
using UnityEngine.InputSystem;

namespace Creatures
{
    public class InputReader : MonoBehaviour
    {
        private HeroMover _heroMover;
        private Vector2 _direction;

        private void Awake()
        {
            _heroMover = GetComponent<HeroMover>();
        }

        public void DoHorizontalMovement(InputAction.CallbackContext context)
        {
            _direction.x = context.ReadValue<float>();
            _heroMover.SetDirection(_direction); 
        }
        
        public void DoJump(InputAction.CallbackContext context)
        {
            _direction.y = context.ReadValue<float>();
            _heroMover.SetDirection(_direction);
        }
    }
}