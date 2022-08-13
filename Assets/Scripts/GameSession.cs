using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    private const string Hud = "HUD";
    public static GameSession I { get; private set; }
    
    private void Awake()
    {
        var existController = GetExistController();
            
        if (existController != null)
        {
            Destroy(gameObject); 
        }
        else
        {
            I = this;
            DontDestroyOnLoad(this);
        }
            
        LoadUIs();
    }
    
    private void LoadUIs()
    {
        SceneManager.LoadScene(Hud, LoadSceneMode.Additive);
    }
    
    private GameSession GetExistController()
    {
        var controllers = FindObjectsOfType<GameSession>();

        foreach (var controller in controllers) 
        {
            if (controller != this)
            {
                return controller;
            }
        }

        return null;
    }
}