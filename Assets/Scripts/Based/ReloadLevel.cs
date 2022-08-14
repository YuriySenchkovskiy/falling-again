using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Based
{
    public class ReloadLevel : MonoBehaviour
    {
        public void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel(scene.name, true);
        }
    }
}