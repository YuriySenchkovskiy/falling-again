using UnityEngine;

namespace Based
{
    public class DestroyComponent : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void DestroyAnotherGameObject(GameObject go)
        {
            Debug.Log("here");
            Destroy(go);
        }
    }
}