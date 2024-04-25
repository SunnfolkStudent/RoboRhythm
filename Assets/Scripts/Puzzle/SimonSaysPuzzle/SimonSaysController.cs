using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Puzzle2Controller : MonoBehaviour
{
    [SerializeField] private Puzzle2Scrub _scrub;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Button startButton;
    [SerializeField] private Button victoryButton;
    
    [SerializeField] private PuzzleManager _puzzleManager;
    
    private int _currentNumber;
    
    private IEnumerator Puzzle2Coroutine()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        yield return new WaitForSeconds(0.5f);
        
        foreach (var number in _scrub.puzzle)
        {
            _buttons[number-1].Select();
            yield return new WaitForSeconds(0.75f);
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForSeconds(0.25f);
        }
        
        Cursor.lockState = CursorLockMode.None;
    }

    public void ButtonMethod(int number)
    {
        if (number == _scrub.puzzle[_currentNumber])
        {
            _currentNumber++;
        } 
        else
        {
            _currentNumber = 0;
            StartCoroutine(Puzzle2Coroutine());
        }
        
        if (_currentNumber == _scrub.puzzle.Length)
        {
            PuzzleCompleted();
        }
    }
    
    public void StartButtonMethod()
    {
        startButton.gameObject.SetActive(false);
        StartCoroutine(Puzzle2Coroutine());
    }
    
    public void VictoryButtonMethod()
    {
        // Get the current scene
        Scene currentScene = gameObject.scene;

        // Unload the current scene
        PuzzleEvents.unloadPuzzle?.Invoke(currentScene);
    }
    
    private void PuzzleCompleted()
    {
        _puzzleManager.PuzzleOver();
        victoryButton.gameObject.SetActive(true);
    }
}
