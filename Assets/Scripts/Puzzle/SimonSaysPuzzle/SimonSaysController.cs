using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Puzzle2Controller : PuzzleControllerBase
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Button startButton;
    private int _difficulty = 8;
    
    private List<int> _puzzle = new List<int>();
    
    private int _currentNumber;
    

    private void Start()
    {
        //Make every button except startbutton disabled
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
    }

    private IEnumerator Puzzle2Coroutine()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Create random 15 number puzzle
        _puzzle.Clear();
        for (int i = 0; i < _difficulty; i++)
        {
            _puzzle.Add(Random.Range(0, 9));
        }
        
        yield return new WaitForSeconds(0.5f);
        
        foreach (var number in _puzzle)
        {
            _buttons[number].Select();
            yield return new WaitForSeconds(0.75f);
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForSeconds(0.25f);
        }
        
        Cursor.lockState = CursorLockMode.None;
    }

    public void ButtonMethod(int number)
    {
        if (number == _puzzle[_currentNumber])
        {
            _currentNumber++;
        } 
        else
        {
            _currentNumber = 0;
            StartCoroutine(Puzzle2Coroutine());
        }
        
        if (_currentNumber == _puzzle.Count)
        {
            PuzzleCompleted();
        }
    }
    
    public void StartButtonMethod()
    {
        //Make buttons enabled
        foreach (var button in _buttons)
        {
            button.interactable = true;
        }
        
        startButton.gameObject.SetActive(false);
        StartCoroutine(Puzzle2Coroutine());
    }
}
