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
        
        

        if (_input.Player.Up.WasPressedThisFrame())
        {
            PlayerEvents.playerMovePress?.Invoke(Vector2.up);
        }
        if (_input.Player.Down.WasPressedThisFrame())
        {
            PlayerEvents.playerMovePress?.Invoke(Vector2.down);
        }
        if (_input.Player.Left.WasPressedThisFrame())
        {
            PlayerEvents.playerMovePress?.Invoke(Vector2.left);
        }
        if (_input.Player.Right.WasPressedThisFrame())
        {
            PlayerEvents.playerMovePress?.Invoke(Vector2.right);
        }

        if (_input.Player.Right.WasReleasedThisFrame())
        {
            PlayerEvents.playerMoveRelease?.Invoke(Vector2.right);
        }
        if (_input.Player.Left.WasReleasedThisFrame())
        {
            PlayerEvents.playerMoveRelease?.Invoke(Vector2.left);
        }
        if (_input.Player.Up.WasReleasedThisFrame())
        {
            PlayerEvents.playerMoveRelease?.Invoke(Vector2.up);
        }
        if (_input.Player.Down.WasReleasedThisFrame())
        {
            PlayerEvents.playerMoveRelease?.Invoke(Vector2.down);
        }
        
        
        if (_input.Player.Run.WasPressedThisFrame())
        {
            PlayerEvents.playerRunning?.Invoke();
        }
        if (_input.Player.Run.WasReleasedThisFrame())
        {
            PlayerEvents.playerNotRunning?.Invoke();
        }

        if (_input.UI.Pause.WasPressedThisFrame())
        {
            GameEvents.pausePressed?.Invoke();
        }

        if (_input.Puzzle.SpaceKey.WasPressedThisFrame())
        {
            PuzzleEvents.spacePressed?.Invoke();
        }
    }
    private void Awake()
    {
        _input = new Controls();
    }
    
    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }
}