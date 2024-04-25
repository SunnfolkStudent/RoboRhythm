using UnityEngine.SceneManagement;

public static class GameEvents
{
    public delegate void GameEvent();
    public static GameEvent gamePaused;
    public static GameEvent gameUnpaused;
    
    public delegate void LoadingEvent(string sceneName);
    public static LoadingEvent unloadScene;
}
