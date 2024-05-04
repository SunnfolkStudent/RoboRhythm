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

    private Scene _mainScene;

    protected void Start()
    {
        AudioManager.instance.StopMusic();
        _mainScene = SceneManager.GetActiveScene();
        Scene currentScene = gameObject.scene;
        SceneManager.SetActiveScene(currentScene);
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
        SceneManager.SetActiveScene(_mainScene);
        
        AudioManager.instance.StartMusic();
        
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
