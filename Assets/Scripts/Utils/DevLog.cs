using UnityEngine;

namespace Utils
{
    public class DevLog : MonoBehaviour
    {
        [SerializeField] private string _message;

        private void ShowMessage()
        {
            Debug.Log(_message);
        }
    }
}