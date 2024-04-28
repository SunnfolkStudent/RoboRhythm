using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBossPortal : MonoBehaviour, IDataPersistence
{
    [SerializeField] private int endSceneStartId; 
    [SerializeField] private GameObject visualCue;
    
    private bool allKeysFound;
    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if(allKeysFound)
        {
            if (playerInRange)
            {
                visualCue.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene(endSceneStartId);
                }
            }
            else
            {
                visualCue.SetActive(false);
            }
        }
    }

    public void LoadData(GameData data)
    {
        allKeysFound = data.hasAllKeys;
    }
    public void SaveData(GameData data)
    {
        data.hasAllKeys = allKeysFound;
    }
    public void SaveTaskData(GameData data) { }
    public void LoadTaskData(GameData data) { }
    public void LoadKeyData(GameData data)
    {
        allKeysFound = data.hasAllKeys;
    }
    public void SaveKeyData(GameData data)
    {
        data.hasAllKeys = allKeysFound;
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
}
