using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _playButton;
        [SerializeField] private GameObject _controllInfo;
        [SerializeField] private string _sceneName;
        [SerializeField] private float _waitTime;

        private void Awake()
        {
            Invoke(nameof(TurnOnPlayButton), _waitTime);
        }

        public void OnClick()
        {
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel(_sceneName);
        }
        
        private void TurnOnPlayButton()
        {
            _playButton.SetActive(true);

            if (_controllInfo != null)
            {
                _controllInfo.gameObject.SetActive(true);
            }
        }
    }
}