using UnityEngine;
using UnityEngine.Events;

namespace Utils.ObjectPool
{
    public class PoolItem : MonoBehaviour
    {
        [SerializeField] private float _releasePointLeft;
        [SerializeField] private bool _isUseReleasePointRight;
        [SerializeField] private float _releasePointRight;
        [SerializeField] private UnityEvent _restart;

        private int _id;
        private Pool _pool;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Vector3 disablePointLeft = _camera.ViewportToWorldPoint(new Vector2(_releasePointLeft, 0f));
            Vector3 disablePointRight = _camera.ViewportToWorldPoint(new Vector2(_releasePointRight, 0f));

            if (gameObject.transform.position.x < disablePointLeft.x)
            {
                Release();
            }
            else if (_isUseReleasePointRight && gameObject.transform.position.x > disablePointRight.x)
            {
                Release();
            }
        }

        public void Restart()
        {
            _restart?.Invoke();
        }
        
        [ContextMenu("Release")]
        public void Release()
        {
            _pool.Release(_id, this);
        }

        public void Retain(int id, Pool pool)
        {
            _id = id;
            _pool = pool;
        }
    }
}