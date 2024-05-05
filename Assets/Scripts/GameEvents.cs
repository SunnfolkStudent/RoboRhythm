using UnityEngine.SceneManagement;

public static class GameEvents
{
    public delegate void GameEvent();
    public static GameEvent gamePaused;
    public static GameEvent gameUnpaused;
    public static GameEvent pausePressed;
    public static GameEvent unPauseGame;
    public static GameEvent goingToMainMenu;
}
