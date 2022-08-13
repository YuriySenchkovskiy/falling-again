using UnityEngine;

namespace Based
{
    public class DestroyComponent : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}