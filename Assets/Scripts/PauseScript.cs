using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private string[] nonoScenes;
    
    private void Awake()
    {
        PauseScript[] instances = FindObjectsOfType<PauseScript>();
        if (instances.Length > 1)
        {
            for (int i = 0; i < instances.Length; i++)
            {
                if (i != 0)
                {
                    Destroy(instances[i].gameObject);
                }
            }
        }
        
        DontDestroyOnLoad(gameObject);
    }
    
    private void OnEnable()
    {
        GameEvents.pausePressed += PauseGame;
        GameEvents.unPauseGame += UnPauseGame;
    }
    
    private void OnDisable()
    {
        GameEvents.pausePressed -= PauseGame;
        GameEvents.unPauseGame -= UnPauseGame;
    }
    
    private void PauseGame()
    {
        if (SceneManager.GetSceneByName("PauseScene").isLoaded)
        {
            SceneManager.UnloadSceneAsync("PauseScene");
            return;
        }

        foreach (var scene in nonoScenes)
        {
            if (SceneManager.GetSceneByName(scene).isLoaded)
            {
                return;
            }
        }
        
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
    }
    
    public void UnPauseGame()
    {
        SceneManager.UnloadSceneAsync("PauseScene");
    }
}
