using System;
using UnityEngine;
using Utils.Disposable;

namespace UI
{
    public class LoaderInputController : MonoBehaviour
    {
        private static Action _animatedEnded;
        private static Action _animatedStarted;
        
        public static IDisposable Subscribe(Action callOne, Action callTwo)
        {
            _animatedEnded += callOne;
            _animatedStarted += callTwo;
            return new ActionDisposable(() =>
            {
                _animatedEnded -= callOne;
                _animatedStarted -= callTwo;
            });
        }

        private void StartAnimate()
        {
            _animatedStarted?.Invoke();
        }

        private void EndAnimate()
        {
            _animatedEnded?.Invoke();
        }
    }
}