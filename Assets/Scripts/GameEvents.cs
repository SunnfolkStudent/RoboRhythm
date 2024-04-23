public static class GameEvents
{
    public delegate void LoadingEvent(string sceneName);
    public static LoadingEvent unloadScene;
}
