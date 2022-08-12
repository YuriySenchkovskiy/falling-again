using System;
using UnityEngine;
using UnityEngine.Events;

namespace Animation
{
    [Serializable]
    public class AnimationClip
    {
        [SerializeField] private string _name;
        [SerializeField] private bool _loop;
        [SerializeField] private bool _random;
        [SerializeField] private bool _allowNextClip;
            
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _complited;
            
        public string Name => _name;
        public Sprite[] Sprites => _sprites;
        public bool Loop => _loop;
        public bool Random => _random;
        public bool AllowNextClip => _allowNextClip;
        public UnityEvent Complited => _complited;
    }
}