using UnityEngine;

public class PauseEnablerClass : MonoBehaviour
{
    protected bool gameIsPaused;
    
    protected void PausedGame()
    {
        gameIsPaused = true;
    }
    
    protected void UnPausedGame()
    {
        gameIsPaused = false;
    }

    protected virtual void OnEnable()
    {
        GameEvents.gamePaused += PausedGame;
    }
    
    protected virtual void OnDisable()
    {
        GameEvents.gameUnpaused -= UnPausedGame;
    }
}
