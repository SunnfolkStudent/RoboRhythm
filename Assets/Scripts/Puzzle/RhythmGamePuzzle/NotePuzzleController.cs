using UnityEngine;
using UnityEngine.UI;
public class NotePuzzleController : PuzzleControllerBase
{
    private NoteSpawner _noteSpawner;
    [SerializeField] private NotePuzzleScrub _notePuzzleScrub;
    [SerializeField] private GameObject _noteObj;
    [SerializeField] private Button _startButton;
    
    // Start is called before the first frame update
    private void Start()
    {
        _noteSpawner = new NoteSpawner(_notePuzzleScrub, _noteObj);
    }

    private void OnEnable()
    {
        PuzzleEvents.resetPuzzle += ResetPuzzle;
        PuzzleEvents.puzzleCompleted += PuzzleCompleted;
    }
    
    private void OnDisable()
    {
        PuzzleEvents.resetPuzzle -= ResetPuzzle;
        PuzzleEvents.puzzleCompleted -= PuzzleCompleted;
    }
    
    public void StartButtonMethod()
    {
        _startButton.gameObject.SetActive(false);
        _noteSpawner.SpawnNotes();
    }
    
    private void ResetPuzzle()
    {
        _startButton.gameObject.SetActive(true);
    }
}
