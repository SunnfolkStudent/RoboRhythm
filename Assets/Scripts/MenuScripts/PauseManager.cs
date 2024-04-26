using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    private void Start()
    {
        Time.timeScale = 0;
        GameEvents.gamePaused?.Invoke();
    }
    
    public void ResumeGame()
    {
        print("hI");
        Time.timeScale = 1;
        GameEvents.gameUnpaused?.Invoke();
        GameEvents.unloadScene?.Invoke("PauseMenu");
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
