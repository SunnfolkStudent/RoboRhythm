using UnityEngine;
 
public class NotePuzzleController : PuzzleControllerBase
{
    private NoteSpawner _noteSpawner;
    private NotePuzzleScrub _notePuzzleScrub;
    [SerializeField] private GameObject _noteObj;

    private void OnEnable()
    {
        PuzzleEvents.resetPuzzle += ResetPuzzle;
        PuzzleEvents.puzzleCompleted += PuzzleCompletedCheckpoint;
    }
    
    private void OnDisable()
    {
        PuzzleEvents.resetPuzzle -= ResetPuzzle;
        PuzzleEvents.puzzleCompleted -= PuzzleCompletedCheckpoint;
    }
    
    private void ResetPuzzle()
    {
        startButton.gameObject.SetActive(true);
    }
    
    private void PuzzleCompletedCheckpoint()
    {
        _noteSpawner = null;
        PuzzleCompleted();
    }
    
    protected override void StartPuzzle()
    {
        _noteSpawner ??= new NoteSpawner(puzzles[completedPuzzles] as NotePuzzleScrub, _noteObj);

        _noteSpawner.SpawnNotes();
    }
}
