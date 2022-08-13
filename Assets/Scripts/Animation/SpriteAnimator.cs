using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Animation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimator : MonoBehaviour
    {
        [Header("Settings")] 
        [SerializeField] [Range(1, 30)] private int _frameRate = 10;
        [SerializeField] private AnimationClip[] _clips;
        [SerializeField] private UnityEvent<string> _endAnimation;
        
        private SpriteRenderer _renderer;
        private float _secondPerFrame;
        private float _nextFrameTime; 
        private int _currentFrame;
        
        private bool _isPlaying = true;
        private int _currentClip;
        private int _nextClip = 1;

        private void OnEnable() 
        {
            _nextFrameTime = Time.time;
        }

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _secondPerFrame = 1f / _frameRate;
            StartAnimation();
        }

        private void OnBecameVisible() 
        {
            //enabled = _isPlaying;
        }

        private void OnBecameInvisible()
        {
            //enabled = false;
        }

        private void Update()
        {
            if (_nextFrameTime > Time.time)
            {
                return;
            }
            
            var clip = _clips[_currentClip]; 
            if (_currentFrame >= clip.Sprites.Length)
            {
                if (clip.Loop)
                {
                    _currentFrame = 0;
                }
                else
                {
                    enabled = _isPlaying = clip.AllowNextClip;
                    clip.Complited?.Invoke();
                    _endAnimation?.Invoke(clip.Name);

                    if (clip.AllowNextClip)
                    {
                        _currentFrame = 0;
                        _currentClip = (int) Mathf.Repeat(_currentClip + _nextClip, _clips.Length);
                    }
                }

                return;
            }

            _renderer.sprite = clip.Sprites[_currentFrame];
            _nextFrameTime += _secondPerFrame;
            _currentFrame++;
        }
        
        public void SetClip(string name)
        {
            for (var i = 0; i < _clips.Length; i++)
            {
                if (_clips[i].Name == name)
                {
                    _currentClip = i;
                    StartAnimation();
                    return;
                }
            }

            enabled = _isPlaying = false;
        }

        private void StartAnimation()
        {
            _nextFrameTime = Time.time;
            enabled = _isPlaying = true;
            if (!_clips[_currentClip].Random)
            {
                _currentFrame = 0; 
            }
            else
            {
                _currentFrame = Random.Range(0, _clips[_currentClip].Sprites.Length);
            }
        }
    }
}