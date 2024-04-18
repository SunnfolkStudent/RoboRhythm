public static class PuzzleEvents
{
    public delegate void KeyPressed(string key);
    public static KeyPressed OnKeyPressed;
}
