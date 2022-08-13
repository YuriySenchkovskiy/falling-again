using UnityEngine;
using Utils;
using Utils.ObjectPool;

namespace Based
{
    public class SpawnComponent : MonoBehaviour
    {
        [Space] [Header("Base")]
        [SerializeField] protected string ContainerName;
        [SerializeField] protected Transform Target;
        [SerializeField] protected GameObject Prefab; 
       
        [Space] [Header("InvertScale")]
        [SerializeField] protected bool IsInvertXScale;
        [SerializeField] protected bool IsInvertYScale;
        
        [Space] [Header("Destination")]
        [SerializeField] protected bool IsUsePool;
        [SerializeField] protected bool IsUseCameraPool;
        [SerializeField] protected bool IsHudSpawn;
        
        [Space] [Header("Random Spawn point")]
        [SerializeField] protected bool IsUseRandomXPoint;
        [SerializeField] protected float XPointStart;
        [SerializeField] protected float XPointEnd;

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
            if (IsUseRandomXPoint)
            {
                var _xAdded = Random.Range(XPointStart, XPointEnd);
                var position = new Vector3(Target.position.x + _xAdded, Target.position.y);
                Target.position = position;
            }

            GameObject instance;

            if (IsUsePool)
            {
                instance = Pool.Instance.GetGameObject(Prefab, Target.position);
            }
            else if (IsUseCameraPool)
            {
                instance = Pool.CameraInstance.GetGameObject(Prefab, Target.position);
            }
            else if (IsHudSpawn)
            {
                instance = SpawnUtils.Spawn(Prefab, Target.position, containerName: ContainerName);
            }
            else
            {
                instance = SpawnUtils.Spawn(Prefab, Target.position);
            }

            var scale = Target.lossyScale;
            scale.x *= IsInvertXScale ? -1 : 1;
            scale.y *= IsInvertYScale ? -1 : 1;
            instance.transform.localScale = scale;
            instance.SetActive(true);
            return instance;
        }
    }
}