using Based;
using Sound;
using UnityEngine;

namespace Creatures
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpawnListComponent), typeof(Animator))]
    [RequireComponent(typeof(SfxSound))]
    public class HeroMover : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] protected LayerCheck WallCheck;
        [SerializeField] protected LayerCheck WallNearCheck;
        [SerializeField, Range(0, 10)] protected float SpeedField;
        [SerializeField] private bool _invertScale;

        private Rigidbody2D _rigidbody2D;
        private Vector2 _direction;
        private Vector3 _forwardScale = Vector3.one; 
        private Vector3 _backwardsScale = new Vector3(-1, 1, 1);
        
        private int _zeroValue = 0;
        private float _minSpeed = 0.01f;
        
        [Space] [Header("Jumping")] 
        [SerializeField, Range(0, 100)] private float _jumpLevel; 
        [SerializeField, Range(0, 100)] private float _damageJumpLevel; 
        [SerializeField] private LayerCheck _layerCheck;
        [SerializeField] private string _jump = "Jump";

        private bool _isGrounded; 
        private bool _isJumping;
        private bool _isOnStartLevel = true;
        
        [Space] [Header("Particles")]
        [SerializeField] private string _run = "Run";
        
        private Animator _animator;
        private SfxSound _sfxSound;
        private SpawnListComponent _particles;
        private string _healSound = "Heal";
        private string _damageSound = "Damage";
        
        private static readonly int _isRunning = Animator.StringToHash("isRunning");
        private static readonly int _isGround = Animator.StringToHash("isGround");
        private static readonly int VerticalVelocity = Animator.StringToHash("verticalVelocity");
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _particles = GetComponent<SpawnListComponent>();
            _animator = GetComponent<Animator>();
            _sfxSound = GetComponent<SfxSound>();
        }
        
        private void Update()
        {
            _isGrounded = _layerCheck.IsTouchingLayer;
        }

        private void FixedUpdate()
        {
            var xVelocity = CalculateXVelocity();
            var yVelocity = CalculateYVelocity();
            _rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
            
            UpdateAnimation(); 
            UpdateSpriteDirection(_direction);
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction; 
        }

        public void SetOffIsOnStartLevel()
        {
            _isOnStartLevel = false;
        }
        
        protected virtual float CalculateSpeed()
        {
            return SpeedField;
        }
        
        private void UpdateSpriteDirection(Vector2 direction)
        {
            var multiplier = _invertScale ? -1 : 1;
            
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(_forwardScale.x * multiplier, _forwardScale.y, _forwardScale.z);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(_backwardsScale.x * multiplier, _backwardsScale.y, _backwardsScale.z);
            }
        }
        
        private float CalculateXVelocity()
        {
            return _direction.x * CalculateSpeed();
        }
        
        private float CalculateYVelocity() 
        {
            var yVelocity = _rigidbody2D.velocity.y;

            if (_isOnStartLevel)
            {
                return yVelocity;
            }
            
            var isJumpPressed = _direction.y > 0;
            var lowJumpLevel = 0.85f;
            
            if (_isGrounded)
            {
                _isJumping = false; 
            }

            if (isJumpPressed) 
            {
                _isJumping = true; 
                
                var isFalling = _rigidbody2D.velocity.y <= 0.001f;
                yVelocity = isFalling ? CalculateJumpVelocity(yVelocity) : yVelocity;
            }
            else if (_rigidbody2D.velocity.y > 0 && _isJumping) 
            {
                yVelocity *= lowJumpLevel; 
            }

            return yVelocity;
        }
        
        private float CalculateJumpVelocity(float yVelocity) 
        {
            if (_isGrounded) 
            {
                yVelocity = _jumpLevel; 
                DoJumpVfx();
            }
            
            return yVelocity;
        }
        
        private void DoJumpVfx()
        {
            _particles.Spawn(_jump);
            _sfxSound.Play();
        }
        
        private void SpawnFootDustInAnimation()
        {
            if (_isGrounded && _rigidbody2D.velocity.y <= _minSpeed)
            {
                _particles.Spawn(_run); 
            }
        }
        
        private void UpdateAnimation() 
        {
            _animator.SetBool(_isGround, _isGrounded);
            _animator.SetFloat(VerticalVelocity, _rigidbody2D.velocity.y); 
            _animator.SetBool(_isRunning, _direction.x != _zeroValue && SpeedField != _zeroValue && _isGrounded); 
        }
    }
}