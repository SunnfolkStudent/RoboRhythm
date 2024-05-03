using System.Collections;
using UnityEngine;

public class RhythmPuzzleController : PuzzleControllerBase
{
    [SerializeField] private ParticleSystem _particleSystem;
    
    private RhythmPuzzleScrub puzzleData;
    private float _lastClickTime = 0f;
    private int _currentNumber;
    private Animator _animator;
    private NoteReference _correctSound;
    private NoteReference _wrongSound;
    
    // Start is called before the first frame update
    void Start()
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

    private IEnumerator PuzzleCoroutine()
    {
        _currentNumber = 0;
        _lastClickTime = 0f;
        puzzleData = puzzles[completedPuzzles] as RhythmPuzzleScrub;
        
        Cursor.lockState = CursorLockMode.Locked;
        
        yield return new WaitForSeconds(0.5f);
        
        foreach (var value in puzzleData.rhythm)
        {
            _animator.Play("Light");
            yield return new WaitForSeconds(value);
        }
        
        yield return new WaitForSeconds(0.5f);
        
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
