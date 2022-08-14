using UnityEngine;

namespace Based
{
    public class SfxSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;

        public void Play()
        {
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
        }
    }
}