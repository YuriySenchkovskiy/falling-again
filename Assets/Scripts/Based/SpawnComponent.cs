using UnityEngine;
using Utils;
using Utils.ObjectPool;

namespace Based
{
    public class SpawnComponent : MonoBehaviour
    {
        [Space] [Header("Base")]
        [SerializeField] protected Transform Target;
        [SerializeField] protected GameObject Prefab; 
       
        [Space] [Header("InvertScale")]
        [SerializeField] protected bool IsInvertXScale;
        [SerializeField] protected bool IsInvertYScale;

        [ContextMenu("Points")]
        public void Spawn()
        {
            SpawnInstance();
        }
        
        public void SetPrefab(GameObject prefab)
        {
            Prefab = prefab;
        }

        protected virtual GameObject SpawnInstance()
        {
            GameObject instance;
            instance = SpawnUtils.Spawn(Prefab, Target.position);
            
            var scale = Target.lossyScale;
            scale.x *= IsInvertXScale ? -1 : 1;
            scale.y *= IsInvertYScale ? -1 : 1;
            instance.transform.localScale = scale;
            instance.SetActive(true);
            return instance;
        }
    }
}