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
            var waitTime = timer.IsUseRandom ? 
                new WaitForSeconds(Random.Range(timer.FromValue, timer.ToValue)) : new WaitForSeconds(timer.Delay);
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
            public bool IsUseRandom;
            public float FromValue;
            public float ToValue;
            public UnityEvent EventAtTheEnd;
        }
    }
}