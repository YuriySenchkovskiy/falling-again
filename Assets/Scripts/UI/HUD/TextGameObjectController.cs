using UnityEngine;

namespace UI.HUD
{
    public class TextGameObjectController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void EndAnimation()
        {
            _animator.SetTrigger("Close");
        }

        private void TurnOffText()
        {
            gameObject.SetActive(false);
        }
    }
}