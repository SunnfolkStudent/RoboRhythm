using UnityEngine;

public class Input_Controller : MonoBehaviour
{
    private  Controls _input;
    
    private void Update()
    {
        if (_input.Puzzle.AKey.WasPressedThisFrame())
        {
            PuzzleEvents.OnKeyPressed?.Invoke('A');
        }
        if (_input.Puzzle.SKey.WasPressedThisFrame())
        {
            PuzzleEvents.OnKeyPressed?.Invoke('S');
        }
        if (_input.Puzzle.DKey.WasPressedThisFrame())
        {
            PuzzleEvents.OnKeyPressed?.Invoke('D');
        }
        if (_input.Puzzle.JKey.WasPressedThisFrame())
        {
            PuzzleEvents.OnKeyPressed?.Invoke('J');
        }
        if (_input.Puzzle.KKey.WasPressedThisFrame())
        {
            PuzzleEvents.OnKeyPressed?.Invoke('K');
        }
        if (_input.Puzzle.LKey.WasPressedThisFrame())
        {
            PuzzleEvents.OnKeyPressed?.Invoke('L');
        }
        
        

        if (_input.Player.Up.IsPressed())
        {
            PlayerEvents.playerUp?.Invoke();
        }
        if (_input.Player.Down.IsPressed())
        {
            PlayerEvents.playerDown?.Invoke();
        }
        if (_input.Player.Left.IsPressed())
        {
            PlayerEvents.playerLeft?.Invoke();
        }
        if (_input.Player.Right.IsPressed())
        {
            PlayerEvents.playerRight?.Invoke();
        }
    }
    private void Awake()
    {
        _input = new Controls();
    }
    
    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }
}