using TMPro;
using UnityEngine;

namespace UI.HUD
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private TextGameObjectController _jumpText;
        [SerializeField] private TextGameObjectController _toFinishText;
        [SerializeField] private TextGameObjectController _toBottomText;
        [SerializeField] private TextGameObjectController _winText;

        private TMP_Text _finishText;
        private TMP_Text _bottomText;
        private string _metres = " m";
        private GroundController.GroundController _groundController;

        private void Awake()
        {
            _groundController = FindObjectOfType<GroundController.GroundController>();
            _groundController.HeroTouchedBottom += OnHeroTouchedBottom;
            _groundController.HeroTouchedFinish += OnHeroTouchedFinish;
            _groundController.HeroTouchedGround += OnHeroTouchedGround;

            _groundController.CalculatedToFinish += OnCalculatedToFinish;
            _groundController.CalculatedToBottom += OnCalculatedToBottom;

            _finishText = _toFinishText.GetComponent<TMP_Text>();
            _bottomText = _toBottomText.GetComponent<TMP_Text>();
        }

        private void OnDisable()
        {
            _groundController.HeroTouchedBottom -= OnHeroTouchedBottom;
            _groundController.HeroTouchedFinish -= OnHeroTouchedFinish;
            _groundController.HeroTouchedGround -= OnHeroTouchedGround;
            
            _groundController.CalculatedToFinish -= OnCalculatedToFinish;
            _groundController.CalculatedToBottom -= OnCalculatedToBottom;
        }

        private void OnHeroTouchedGround()
        {
            SetTextStatus(true);
        }

        private void OnHeroTouchedFinish()
        {
           _toBottomText.EndAnimation();
           _toFinishText.EndAnimation();
           _winText.gameObject.SetActive(true);
        }

        private void OnHeroTouchedBottom()
        {
            // _toBottomText.EndAnimation();
            // _toFinishText.EndAnimation();

            SetTextStatus(false);
        }

        private void SetTextStatus(bool status)
        {
            _jumpText.gameObject.SetActive(status);
            _toFinishText.gameObject.SetActive(status);
            _toBottomText.gameObject.SetActive(status);
        }

        private void OnCalculatedToFinish(int distance)
        {
            _finishText.text = distance + _metres;
        }

        private void OnCalculatedToBottom(int distance)
        {
            _bottomText.text = distance + _metres;
        }
    }
}