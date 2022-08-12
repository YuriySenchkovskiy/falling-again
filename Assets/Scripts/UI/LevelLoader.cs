using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _transitionTime;

        private const string LevelLoaderSceneName = "LevelLoader";
        private static readonly int Enabled = Animator.StringToHash("Enable");
        private WaitForSeconds _waitTime;
        
        private void Awake()
        {
            _waitTime = new WaitForSeconds(_transitionTime);
            DontDestroyOnLoad(gameObject);
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void OnAfterSceneLoad()
        {
            InitLoad();
        }
        
        private static void InitLoad()
        {
            SceneManager.LoadScene(LevelLoaderSceneName, LoadSceneMode.Additive);
        }
        
        public void LoadLevel(string sceneName)
        {
            StartCoroutine(StartAnimation(sceneName));
        }
        
        private IEnumerator StartAnimation(string sceneName)
        {
            _animator.SetBool(Enabled, true);
            yield return _waitTime;
            SceneManager.LoadScene(sceneName);
            _animator.SetBool(Enabled, false);
        }
    }
}