using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RhythmPuzzleController : MonoBehaviour
{
    [SerializeField] private RhythmPuzzleScrub puzzleData;
    [SerializeField] private Button _button;
    
    private float _lastClickTime = 0f;
    private int _currentNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PuzzleCoroutine());
    }

    private IEnumerator PuzzleCoroutine()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        foreach (var value in puzzleData.rhythm)
        {
            _button.Select();
            yield return new WaitForSeconds(0.1f);
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForSeconds(value-0.1f);
        }
        
        Cursor.lockState = CursorLockMode.None;
    }

    public void ButtonMethod()
    {
        float currentTime = Time.time;
        if (_lastClickTime != 0f)
        {
            float timeBetweenClicks = currentTime - _lastClickTime;
            Debug.Log("Time between clicks: " + timeBetweenClicks + " seconds");

            if (timeBetweenClicks > (puzzleData.rhythm[_currentNumber] - 0.15) && timeBetweenClicks < (puzzleData.rhythm[_currentNumber] + 0.15))
            {
                _currentNumber++;
            }
            else
            {
                _currentNumber = 0;
                StartCoroutine(PuzzleCoroutine());
            }

            if (_currentNumber == puzzleData.rhythm.Length)
            {
                print("Rhythm puzzle complete!");
            }
        }
        _lastClickTime = currentTime;
    }
}
