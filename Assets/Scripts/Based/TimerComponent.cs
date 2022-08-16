using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Based
{
    public class TimerComponent : MonoBehaviour
    {
        [SerializeField] private bool _isCountFromStart;
        [SerializeField] private int _timerNumber;
        [SerializeField] private float _multiplicator = 2;
        [SerializeField] private bool _isUseRandom;
        
        [SerializeField] private float _fromValue;
        [SerializeField] private float _toValue;
        [SerializeField] private TimerData[] _timers;

        private void Start()
        {
            if (_isCountFromStart)
            {
                SetTimer(_timerNumber);
            }
        }
        
        public void SetTimer(int index)
        {
            var timer = _timers[index];
            var waitTime = _isUseRandom ? 
                new WaitForSeconds(Random.Range(_fromValue, _toValue)) : new WaitForSeconds(timer.Delay  * _multiplicator);
            StartCoroutine(StartTimer(timer, waitTime));
        }

        private IEnumerator StartTimer(TimerData timer, WaitForSeconds waitTime)
        {
            yield return waitTime; 
            timer.EventAtTheEnd?.Invoke();
        }
        
        [Serializable]
        public class TimerData
        {
            public float Delay;
            public UnityEvent EventAtTheEnd;
        }
    }
}