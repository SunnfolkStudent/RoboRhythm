using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IDataPersistence
{
    [Header("NPC Information")]
    [SerializeField] private string npcId;
    [SerializeField] private Collider2D taskCollider;
    [SerializeField] private string currentStage = "";
    [SerializeField] private bool givenTask;
    
    [Header("Visual Cue")] 
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")] 
    [SerializeField] private TextAsset firstInkJSON;
    [SerializeField] private TextAsset beforeKeyInkJSON;
    [SerializeField] private TextAsset receiveKeyInkJSON;
    [SerializeField] private TextAsset afterKeyInkJSON;
    
    private const string FIRST = "First";
    private const string SECOND = "Second";
    private const string THIRD = "Third";
    private const string FOURTH = "Fourth";
    
    [SerializeField] private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        givenTask = false;
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                PickDialogue();
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void PickDialogue()
    {
        if(currentStage == null)
        {
            currentStage = "First";
        }

        if(givenTask)
        {
            DataPersistenceManager.instance.LoadTaskData();
        }
        
        switch (currentStage)
        {
            case FIRST:
                DialogueManager.GetInstance().EnterDialogueMode(firstInkJSON);
                currentStage = "Second";
                givenTask = true;
                if(taskCollider != null)
                {
                    taskCollider.enabled = true;
                }
                break;
            case SECOND:
                DialogueManager.GetInstance().EnterDialogueMode(beforeKeyInkJSON);
                break;
            case THIRD:
                DialogueManager.GetInstance().EnterDialogueMode(receiveKeyInkJSON);
                currentStage = "Fourth";
                break;
            case FOURTH:
                DialogueManager.GetInstance().EnterDialogueMode(afterKeyInkJSON);
                break;
            default:
                Debug.LogWarning("Stage isn't registered");
                break;
        }
        
        DataPersistenceManager.instance.SaveGame();
        DataPersistenceManager.instance.LoadGame();
    }
    
    public void LoadData(GameData data)
    {
        data.npcStages.TryGetValue(npcId, out currentStage);
        if (currentStage == SECOND)
        {
            taskCollider.enabled = true;
        }
    }

    public void SaveData(GameData data)
    {
        if (data.npcStages.ContainsKey(npcId))
        {
            data.npcStages.Remove(npcId);
        }
        if(currentStage == null)
        {
            currentStage = "First";
        }
        data.npcStages.Add(npcId, currentStage);
    }

    public void SaveTaskData(GameData data) { }

    public void LoadTaskData(GameData data)
    {
        data.npcStages.TryGetValue(npcId, out currentStage);
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
    
    public void LoadKeyData(GameData data){}
    public void SaveKeyData(GameData data){}
}
