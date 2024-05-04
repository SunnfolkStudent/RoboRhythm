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

    private string _mainSceneName;

    protected void Start()
    {
        AudioManager.instance.StopMusic();
        _mainSceneName = SceneManager.GetActiveScene().name;
        Scene currentScene = gameObject.scene;
        SceneManager.SetActiveScene(currentScene);
        
        RestOfStart();
    }
    
    protected virtual void RestOfStart() {}

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
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        
        Scene mainScene = SceneManager.GetSceneByName(_mainSceneName);
        if (mainScene.IsValid())
        {
            SceneManager.SetActiveScene(mainScene);
        }
        
        AudioManager.instance.StartMusic();
        
        // Get the current scene
        Scene currentScene = gameObject.scene;

        // Unload the current scene
        PuzzleEvents.unloadPuzzle?.Invoke(currentScene);
    }
    
    public void StartButtonMethod()
    {
        AudioManager.instance.PlayOneShot(FmodEvents.instance.buttonClick, gameObject.transform.position);
        
        startButton.gameObject.SetActive(false);
        StartPuzzle();
    }
}
