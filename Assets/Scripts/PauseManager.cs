using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    private void Start()
    {
        Time.timeScale = 0;
        
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        GameEvents.unloadScene?.Invoke("PauseMenu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
