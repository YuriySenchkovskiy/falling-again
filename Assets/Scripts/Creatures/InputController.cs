using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Disposable;

namespace Creatures
{
    public class InputController : MonoBehaviour
    {
        [SerializeField]private PlayerInput _input;
        
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private void Awake()
        {
            _trash.Retain(LoaderInputController.Subscribe(TurnOnInput, TurnOffInput));
        }
        
        private void OnDisable()
        {
            _trash.Dispose();
        }

        public void TurnOnInput()
        {
            _input.enabled = true;
        }
        
        public void TurnOffInput()
        {
            _input.enabled = false;
        }
    }
}