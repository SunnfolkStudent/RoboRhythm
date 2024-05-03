using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleControllerBase : MonoBehaviour
{
    [Header("RunManager")] 
    [SerializeField] protected PuzzleScrubBase[] puzzles;
    protected int completedPuzzles;
    
    [SerializeField] protected Button victoryButton;
    [SerializeField] protected Button startButton;
    [SerializeField] protected string taskId;

    protected void Start()
    {
        AudioManager.instance.StopMusic();
    }

    protected void OnDestroy()
    {
        AudioManager.instance.StartMusic();
    }

    protected void PuzzleCompleted()
    {
        completedPuzzles++;
        if (completedPuzzles == puzzles.Length)
        {
            CompletePuzzles();
        }
        else
        {
            startButton.gameObject.SetActive(true);
        }
    }

    protected void CompletePuzzles()
    {
        victoryButton.gameObject.SetActive(true);
        TaskManager.GetInstance().TaskComplete(taskId);
    }
    
    protected virtual void StartPuzzle() {}
    
    public void VictoryButtonMethod()
    {
        // Get the current scene
        Scene currentScene = gameObject.scene;

        // Unload the current scene
        PuzzleEvents.unloadPuzzle?.Invoke(currentScene);
    }
    
    public void StartButtonMethod()
    {
        startButton.gameObject.SetActive(false);
        StartPuzzle();
    }
}
