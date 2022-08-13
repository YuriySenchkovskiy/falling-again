using Creatures;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Animator))]
    public abstract class AnimatedWindowController : MonoBehaviour
    {
        private static readonly int Show = Animator.StringToHash("Show");
        private static readonly int Hide = Animator.StringToHash("Hide");
        
        private Animator _animator;
        private float _startTimeScale;
        private InputController _inputController;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _inputController = FindObjectOfType<HeroMover>().GetComponent<InputController>();
            _inputController.TurnOffInput();
        }

        protected virtual void Start() 
        {
            _animator.SetTrigger(Show);
            _startTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        public void Close()
        {
            _animator.SetTrigger(Hide);
            _inputController.TurnOnInput(); 
            Time.timeScale = _startTimeScale;
        }

        private void OnClosedAnimationComplete()
        {
            Destroy(gameObject);
        }
    }
}