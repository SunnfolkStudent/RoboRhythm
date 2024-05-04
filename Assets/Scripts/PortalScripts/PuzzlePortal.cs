using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzlePortal : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string taskId;
    [SerializeField] private int sceneId;
    [SerializeField] private bool taskDone;
    [SerializeField] private Collider2D _collider;
    
    [SerializeField] private GameObject visualCue;
    
    private string npcStage;
    private bool puzzleActive;

    [SerializeField] private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        puzzleActive = false;
    }

    private void OnEnable()
    {
        PuzzleEvents.unloadPuzzle += UnLoadPuzzle;
    }
    
    private void OnDisable()
    {
        PuzzleEvents.unloadPuzzle -= UnLoadPuzzle;
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E) && !puzzleActive)
            {
                DataPersistenceManager.instance.SaveGame();
                PlayerEvents.playerFrozen?.Invoke();
                puzzleActive = true;
                SceneManager.LoadScene(sceneId, LoadSceneMode.Additive);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    public void LoadData(GameData data)
    {
        data.tasksList.TryGetValue(taskId, out taskDone);
        data.npcStages.TryGetValue(taskId, out npcStage);
        
        if (taskDone)
        {
            _collider.enabled = false;
        }
    }

    public void SaveData(GameData data)
    {
        if (data.tasksList.ContainsKey(taskId))
        {
            data.tasksList.Remove(taskId);
        }

        data.tasksList.Add(taskId, taskDone);
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    
    private void UnLoadPuzzle(Scene sceneName)
    {
        SceneManager.UnloadScene(sceneName);
        puzzleActive = false;
        PlayerEvents.playerUnfrozen?.Invoke();
    }
}
