using UnityEngine;

public class EndBossPortal : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject player;
    
    private bool allKeysFound;
    [SerializeField] private bool playerInRange;

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
                    player.transform.position = new Vector3(40, 121f, 0);
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
