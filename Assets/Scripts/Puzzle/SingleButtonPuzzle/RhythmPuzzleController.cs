using System.Collections;
using UnityEngine;

public class RhythmPuzzleController : PuzzleControllerBase
{
    private RhythmPuzzleScrub puzzleData;
    private float _lastClickTime = 0f;
    private int _currentNumber;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private IEnumerator PuzzleCoroutine()
    {
        puzzleData = puzzles[completedPuzzles] as RhythmPuzzleScrub;
        
        _lastClickTime = 0f;
        
        Cursor.lockState = CursorLockMode.Locked;
        
        foreach (var value in puzzleData.rhythm)
        {
            _animator.Play("Light");
            yield return new WaitForSeconds(value);
        }
        
        Cursor.lockState = CursorLockMode.None;
    }

    public void ButtonMethod()
    {
        _animator.Play("ButtonDown");
        float currentTime = Time.time;
        if (_lastClickTime != 0f)
        {
            float timeBetweenClicks = currentTime - _lastClickTime;
            Debug.Log("Time between clicks: " + timeBetweenClicks + " seconds");

            if (timeBetweenClicks > (puzzleData.rhythm[_currentNumber] - 0.10 * puzzleData.rhythm[_currentNumber]) 
                && timeBetweenClicks < (puzzleData.rhythm[_currentNumber] + 0.10 * puzzleData.rhythm[_currentNumber]))
            {
                _currentNumber++;
            }
            else
            {
                _currentNumber = 0;
                StartCoroutine(PuzzleCoroutine());
                return;
            }

            if (_currentNumber == puzzleData.rhythm.Length - 1)
            {
                PuzzleCompleted();
            }
        }
        _lastClickTime = currentTime;
    }
    
    protected override void StartPuzzle()
    {
        // Make buttons enabled
        StartCoroutine(PuzzleCoroutine());
    }
}
