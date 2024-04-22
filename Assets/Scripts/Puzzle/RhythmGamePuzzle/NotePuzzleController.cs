using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NotePuzzleController : MonoBehaviour
{
    private NoteSpawner _noteSpawner;
    [SerializeField] private NotePuzzleScrub _notePuzzleScrub;
    [SerializeField] private GameObject _noteObj;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button victoryButton;
    
    // Start is called before the first frame update
    private void Start()
    {
        _noteSpawner = new NoteSpawner(this, _notePuzzleScrub, _noteObj);
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
    
    public void VictoryButtonMethod()
    {
        // Get the current scene
        Scene currentScene = gameObject.scene;

        // Unload the current scene
        SceneManager.UnloadSceneAsync(currentScene);

    }
    
    private void ResetPuzzle()
    {
        _startButton.gameObject.SetActive(true);
    }
    
    private void PuzzleCompleted()
    {
        victoryButton.gameObject.SetActive(true);
    }
}
