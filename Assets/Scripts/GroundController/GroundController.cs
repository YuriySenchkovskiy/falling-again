using System;
using Creatures;
using UI;
using UnityEngine;

namespace GroundController
{
    public class GroundController : MonoBehaviour
    {
        [SerializeField] private GameObject _destroyPosition;
        [SerializeField] private GameObject _finishLine;
        [SerializeField] private GameObject _bottomLine;
        [SerializeField] private HeroMover _hero;
        [SerializeField] private string _finalLevelName;
        [SerializeField] private float _timeToLoadFinalLevel;

        private int _distanceToFinish;
        private int _distanceToBottom;
        private int _counter;
        
        public Action HeroTouchedGround;
        public Action HeroTouchedFinish;    
        public Action HeroTouchedBottom;
        public Action<int> CalculatedToFinish;
        public Action<int> CalculatedToBottom;
        
        private void FixedUpdate()
        {
            if (_finishLine != null && _bottomLine != null)
            {
                _distanceToFinish = Mathf.CeilToInt(Vector2.Distance(_hero.transform.position, _finishLine.transform.position));
                _distanceToBottom = Mathf.CeilToInt(_hero.transform.position.y - _bottomLine.transform.position.y);
            
                CalculatedToFinish?.Invoke(_distanceToFinish);
                CalculatedToBottom?.Invoke(_distanceToBottom);
            }
        }

        public void DestroyObject()
        {
            _hero.SetOffIsOnStartLevel();
        }

        public void TouchGround()
        {
            HeroTouchedGround?.Invoke();
        }

        public void TouchFinish()
        {
            HeroTouchedFinish?.Invoke();
            Invoke(nameof(LoadFinalScene), _timeToLoadFinalLevel);
        }

        public void TouchBottom()
        {
            HeroTouchedBottom?.Invoke();
        }
        
        private void LoadFinalScene()
        {
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel(_finalLevelName);
        }
    }
}