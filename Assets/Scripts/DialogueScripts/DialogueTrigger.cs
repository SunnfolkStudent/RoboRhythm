using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IDataPersistence
{
    [Header("NPC Information")]
    [SerializeField] private string npcId;
    [SerializeField] private List<Collider2D> taskColliders;
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
    }

    private void Start()
    {
        if (currentStage != "First")
        {
            givenTask = true;
        }
        else
        {
            givenTask = false;
        }
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                DataPersistenceManager.instance.SaveGame();
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
        if(string.IsNullOrEmpty(currentStage))
        {
            currentStage = "First";
        }

        if(givenTask)
        {
            DataPersistenceManager.instance.LoadGame();
        }
        
        switch (currentStage)
        {
            case FIRST:
                DialogueManager.GetInstance().EnterDialogueMode(firstInkJSON);
                currentStage = "Second";
                givenTask = true;
                if(taskColliders != null)
                {
                    foreach (Collider2D taskCollider in taskColliders)
                    {
                        taskCollider.enabled = true;
                    }
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
        if (currentStage == SECOND && taskColliders != null)
        {
            foreach (Collider2D taskCollider in taskColliders)
            {
                taskCollider.enabled = true;
            }
        }
        else
        {
            foreach (Collider2D taskCollider in taskColliders)
            {
                taskCollider.enabled = false;
            }
        }
        if(string.IsNullOrEmpty(currentStage))
        {
            currentStage = "First";
        }
    }

    public void SaveData(GameData data)
    {
        if (data.npcStages.ContainsKey(npcId))
        {
            data.npcStages.Remove(npcId);
        }
        if(string.IsNullOrEmpty(currentStage))
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
