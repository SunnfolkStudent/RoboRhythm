using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Puzzle2Controller : PuzzleControllerBase
{
    [SerializeField] private Puzzle2Scrub _scrub;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Button startButton;
    
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
}
