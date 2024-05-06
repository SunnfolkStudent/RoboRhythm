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
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        Time.timeScale = 1;
        GameEvents.gameUnpaused?.Invoke();
        GameEvents.unPauseGame?.Invoke();
    }
    
    public void BackToMenu()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        Time.timeScale = 1;
        DataPersistenceManager.instance.SaveGame();
        GameEvents.goingToMainMenu?.Invoke();
        SceneManager.LoadScene("MainMenu");
    }
}
