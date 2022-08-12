using UnityEngine;

namespace Utils
{
    public class WindowUtil : MonoBehaviour
    {
        private const string Tag = "MainCanvas";

        public void CreateWindow(string resourcePath)
        {
            var container = gameObject;
            
            var window = Resources.Load<GameObject>(resourcePath);
            var canvas = GameObject.FindWithTag(Tag).GetComponent<Canvas>();
            var go = Instantiate(window, canvas.transform);
            go.transform.SetParent(container.transform);
        }
    }
}