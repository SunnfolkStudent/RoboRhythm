using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("NPC Information")]
    [SerializeField] private string npcId;
    private string currentStage;
    
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
        //DataPersistenceManager.instance.LoadPuzzleData();
        
        if (currentStage == null)
        {
            currentStage = FIRST;
        }
        
        switch (currentStage)
        {
            case FIRST:
                DialogueManager.GetInstance().EnterDialogueMode(firstInkJSON);
                currentStage = "Second";
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
        
        //DataPersistenceManager.instance.SaveGame();
    }
    
    /*public void LoadData(GameData data)
    {
        data.npcStages.TryGetValue(npcId, out currentStage);
    }

    public void SaveData(GameData data)
    {
        if (data.npcStages.ContainsKey(npcId))
        {
            data.npcStages.Remove(npcId);
        }
        data.npcStages.Add(npcId, currentStage);
    }

    public void SavePuzzleData(GameData data) { }

    public void LoadPuzzleData(GameData data)
    {
        data.npcStages.TryGetValue(npcId, out currentStage);
    }*/

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
