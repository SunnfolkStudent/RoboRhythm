using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RhythmPuzzleController : MonoBehaviour
{
    [SerializeField] private RhythmPuzzleScrub puzzleData;
    [SerializeField] private Button _button;
    [SerializeField] private Button victoryButton;
    
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

            if (timeBetweenClicks > (puzzleData.rhythm[_currentNumber] - 0.20 * puzzleData.rhythm[_currentNumber]) 
                && timeBetweenClicks < (puzzleData.rhythm[_currentNumber] + 0.20 * puzzleData.rhythm[_currentNumber]))
            {
                _currentNumber++;
            }
            else
            {
                _currentNumber = 0;
                StartCoroutine(PuzzleCoroutine());
                return;
            }

            if (_currentNumber == puzzleData.rhythm.Length)
            {
                PuzzleCompleted();
            }
        }
        _lastClickTime = currentTime;
    }
    
    public void StartButtonMethod()
    {
        _button.gameObject.SetActive(false);
        StartCoroutine(PuzzleCoroutine());
    }
    
    public void VictoryButtonMethod()
    {
        // Get the current scene
        Scene currentScene = gameObject.scene;

        // Unload the current scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
    
    private void PuzzleCompleted()
    {
        victoryButton.gameObject.SetActive(true);
    }
}
