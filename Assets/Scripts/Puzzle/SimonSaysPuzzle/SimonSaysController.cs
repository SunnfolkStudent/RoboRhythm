using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Puzzle2Controller : PuzzleControllerBase
{
    [SerializeField] private Button[] _buttons;
    private int _difficulty = 8;

    private List<int> _puzzle = new List<int>();
    private SimonSaysScrub _simonSaysScrub;
    private int _currentNumber;
    private NoteReference _correctSound;
    private NoteReference _wrongSound;
    
    
    protected override void RestOfStart()
    {
        foreach (var reference in FmodEvents.instance.noteReferences)
        {
            if (reference.key == noteEnum.CSharp)
            {
                _wrongSound = reference;
            }
            else if (reference.key == noteEnum.TopD)
            {
                _correctSound = reference;
            }
        }
        
        //Make every button except startbutton disabled
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
    }

    private IEnumerator Puzzle2Coroutine()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        yield return new WaitForSeconds(0.5f);
        
        foreach (var number in _puzzle)
        {
            _buttons[number].Select();
            AudioManager.instance.PlayOneShot(_correctSound.noteEvent, gameObject.transform.position);
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
            AudioManager.instance.PlayOneShot(_correctSound.noteEvent, gameObject.transform.position);
        } 
        else
        {
            AudioManager.instance.PlayOneShot(_wrongSound.noteEvent, gameObject.transform.position);
            _currentNumber = 0;
            StartCoroutine(Puzzle2Coroutine());
        }
        
        if (_currentNumber == _puzzle.Count)
        {
            _currentNumber = 0;
            PuzzleCompleted();
        }
    }
    
    protected override void StartPuzzle()
    {
        //Make buttons enabled
        foreach (var button in _buttons)
        {
            button.interactable = true;
        }
        
        _simonSaysScrub = puzzles[completedPuzzles] as SimonSaysScrub;
        _difficulty = _simonSaysScrub.difficulty;
        
        if (puzzles.Length > 0)
        {
            _puzzle.Clear();
        }
        
        for (int i = 0; i < _difficulty; i++)
        {
            _puzzle.Add(Random.Range(0, 9));
        }
        
        StartCoroutine(Puzzle2Coroutine());
    }
}
