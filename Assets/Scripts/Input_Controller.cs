using UnityEngine;

public class Input_Controller : MonoBehaviour
{
    private  Controls _input;
    
    private void Update()
    {
        if (_input.Puzzle.CKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("C");
        }
        if (_input.Puzzle.DKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("D");
        }
        if (_input.Puzzle.EKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("E");
        }
        if (_input.Puzzle.FKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("F");
        }
        if (_input.Puzzle.GKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("G");
        }
        if (_input.Puzzle.AKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("A");
        }
        if (_input.Puzzle.BKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("B");
        }
        if (_input.Puzzle.COctave.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("C Octave");
        }
        if (_input.Puzzle.CSharpKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("C#");
        }
        if (_input.Puzzle.DSharpKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("D#");
        }
        if (_input.Puzzle.FSharpKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("F#");
        }
        if (_input.Puzzle.GSharpKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("G#");
        }
        if (_input.Puzzle.ASharpKey.triggered)
        {
            PuzzleEvents.OnKeyPressed?.Invoke("A#");
        }
    }
    private void Awake()
    {
        _input = new Controls();
    }
    
    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }
}