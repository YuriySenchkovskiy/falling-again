using System;
using Creatures;
using UnityEngine;

namespace GroundController
{
    public class GroundController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _destroyPosition;
        [SerializeField] private GameObject[] _finishLine;
        [SerializeField] private GameObject[] _bottomLine;
        [SerializeField] private HeroMover _hero;

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
            if (_finishLine[_counter] != null && _bottomLine[_counter] != null)
            {
                _distanceToFinish = Mathf.CeilToInt(Vector2.Distance(_hero.transform.position, _finishLine[_counter].transform.position));
                _distanceToBottom = Mathf.CeilToInt(Vector2.Distance(_hero.transform.position, _bottomLine[_counter].transform.position));
            
                CalculatedToFinish?.Invoke(_distanceToFinish);
                CalculatedToBottom?.Invoke(_distanceToBottom);
            }
        }

        public void DestroyObject()
        {
            
        }

        public void TouchGround()
        {
            HeroTouchedGround?.Invoke();
        }

        public void TouchFinish()
        {
            _counter++;
            HeroTouchedFinish?.Invoke();
        }

        public void TouchBottom()
        {
            HeroTouchedBottom?.Invoke();
        }
    }
}