using ColliderBased;
using UnityEngine;

namespace Based
{
    public class DestroyComponent : MonoBehaviour
    {
        [SerializeField] private float _time;

        private void Awake()
        {
            if (_time > 0)
            {
                Invoke(nameof(Destroy), _time);
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void DestroyComponentAtObject()
        {
            Destroy(GetComponent<EnterTriggerComponent>());
        }
    }
}