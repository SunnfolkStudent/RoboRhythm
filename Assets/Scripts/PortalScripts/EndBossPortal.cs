using UnityEngine;

public class EndBossPortal : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera cityCamera, clockRoomCamera;
    
    private bool allKeysFound;
    [SerializeField] private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        clockRoomCamera.enabled = false;
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
                    cityCamera.enabled = false;
                    clockRoomCamera.enabled = true;
                    player.transform.position = new Vector3(40, 121f, 0);
                }
            }
            else
            {
                visualCue.SetActive(false);
            }
        }
        
        
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                cityCamera.enabled = false;
                clockRoomCamera.enabled = true;
                player.transform.position = new Vector3(40, 120.5f, 0);

                //DataPersistenceManager.instance.SaveGame();
                //SceneManager.LoadScene(endSceneStartId);
            }
        }
        else
        {
            visualCue.SetActive(false);
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
