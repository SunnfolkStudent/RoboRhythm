public static class PuzzleEvents
{
    public delegate void KeyPressed(char key);
    public static KeyPressed OnKeyPressed;
    
    public delegate void PuzzleEvent();
    public static PuzzleEvent resetPuzzle;
    public static PuzzleEvent puzzleCompleted;
    
    public delegate void PuzzleLoadingEvent(string sceneName);
    public static PuzzleLoadingEvent unloadPuzzle;
}
