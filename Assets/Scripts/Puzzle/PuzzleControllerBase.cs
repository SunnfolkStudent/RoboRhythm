using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleControllerBase : MonoBehaviour
{
    [SerializeField] private Button victoryButton;
    [SerializeField] private string taskId;
    
    public void PuzzleCompleted()
    {
        victoryButton.gameObject.SetActive(true);
        TaskManager.GetInstance().TaskComplete(taskId);
    }
    
    public void VictoryButtonMethod()
    {
        // Get the current scene
        Scene currentScene = gameObject.scene;

        // Unload the current scene
        PuzzleEvents.unloadPuzzle?.Invoke(currentScene);
    }
}
