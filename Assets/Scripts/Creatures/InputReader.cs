using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private HeroMover _creatureMover;
    private Vector2 _direction;

    private void Awake()
    {
        _creatureMover = GetComponent<HeroMover>();
    }

    public void DoHorizontalMovement(InputAction.CallbackContext context)
    {
        _direction.x = context.ReadValue<float>();
        _creatureMover.SetDirection(_direction); 
    }
        
    public void DoJump(InputAction.CallbackContext context)
    {
        _direction.y = context.ReadValue<float>();
        _creatureMover.SetDirection(_direction);
    }
}