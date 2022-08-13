using System;
using UnityEngine;
using UnityEngine.Events;

namespace ColliderBased
{
    [Serializable]
    public class EnterEventComponent : UnityEvent<GameObject>
    {
    }
}