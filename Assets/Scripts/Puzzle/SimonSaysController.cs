using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Puzzle2Controller : MonoBehaviour
{
    [SerializeField] private Puzzle2Scrub _scrub;
    
    [SerializeField] private Button[] _buttons;
    
    private int _currentNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Puzzle2Coroutine());
    }
    
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
            print("Puzzle 2 complete!");
        }
    }
}
