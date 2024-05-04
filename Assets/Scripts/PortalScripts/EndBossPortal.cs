using UnityEngine;

public class EndBossPortal : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject player;
    
    [SerializeField] private bool playerInRange;

    private bool allKeysFound;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if(playerInRange && AllKeysFound())
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.PlayOneShot(FmodEvents.instance.doorMoving, gameObject.transform.position);
                player.transform.position = new Vector3(40, 121f, 0);
            }
        }else
        {
            visualCue.SetActive(false);
        }
    }

    private bool AllKeysFound()
    {
        DataPersistenceManager.instance.SaveGame();
        DataPersistenceManager.instance.LoadGame();

        return allKeysFound;
    }

    public void LoadData(GameData data)
    {
        allKeysFound = data.hasAllKeys;
    }
    public void SaveData(GameData data)
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
