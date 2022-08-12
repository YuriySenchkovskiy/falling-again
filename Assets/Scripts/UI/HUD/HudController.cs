using UnityEngine;
using Utils;

namespace UI.HUD
{
    public class HudController : MonoBehaviour
    {
        [Space] [Header("Windows")] 
        [SerializeField] private WindowUtil _windowUtil;
        [SerializeField] private string _storePath;
        [SerializeField] private string _mainMenu;
        
        public void ShowMainMenu()
        {
            if (GetWindowStatus())
            {
                _windowUtil.CreateWindow(_mainMenu);
            }
        }

        private bool GetWindowStatus()
        {
            return GetComponentInChildren<AnimatedWindowController>() == null;
        }
    }
}