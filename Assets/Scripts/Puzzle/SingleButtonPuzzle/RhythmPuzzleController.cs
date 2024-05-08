using System;
using System.Collections;
using UnityEngine;

public class RhythmPuzzleController : PuzzleControllerBase
{
    [SerializeField] private ParticleSystem _particleSystem;
    
    private RhythmPuzzleScrub puzzleData;
    private float _lastClickTime = 0f;
    private int _currentNumber;
    private bool _isPlaying;
    private Animator _animator;
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
        
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PuzzleEvents.spacePressed += ButtonMethod;
    }
    
    private void OnDisable()
    {
        PuzzleEvents.spacePressed -= ButtonMethod;
    }

    private IEnumerator PuzzleCoroutine()
    {
        _isPlaying = true;
        _currentNumber = 0;
        _lastClickTime = 0f;
        puzzleData = puzzles[completedPuzzles] as RhythmPuzzleScrub;
        
        Cursor.lockState = CursorLockMode.Locked;
        
        yield return new WaitForSeconds(0.5f);
        
        foreach (var value in puzzleData.rhythm)
        {
            AudioManager.instance.PlayOneShot(_correctSound.noteEvent, gameObject.transform.position);
            _animator.Play("Light");
            yield return new WaitForSeconds(value);
        }
        
        yield return new WaitForSeconds(0.5f);
        
        Cursor.lockState = CursorLockMode.None;
        _isPlaying = false;
    }

    public void ButtonMethod()
    {
        if (_isPlaying)
        {
            return;
        }
        
        _animator.Play("ButtonDown");
        float currentTime = Time.time;
        if (_lastClickTime != 0f)
        {
            float timeBetweenClicks = currentTime - _lastClickTime;

            if (timeBetweenClicks > (puzzleData.rhythm[_currentNumber] - 0.25 * puzzleData.rhythm[_currentNumber]) 
                && timeBetweenClicks < (puzzleData.rhythm[_currentNumber] + 0.25 * puzzleData.rhythm[_currentNumber]))
            {
                _currentNumber++;
            }
            else
            {
                AudioManager.instance.PlayOneShot(_wrongSound.noteEvent, gameObject.transform.position);
                StartCoroutine(PuzzleCoroutine());
                return;
            }

            if (_currentNumber == puzzleData.rhythm.Length - 1)
            {
                PuzzleCompleted();
            }
        }
        _lastClickTime = currentTime;
        AudioManager.instance.PlayOneShot(_correctSound.noteEvent, gameObject.transform.position);
        _particleSystem.Play();
    }
    
    protected override void StartPuzzle()
    {
        // Make buttons enabled
        StartCoroutine(PuzzleCoroutine());
    }
}
