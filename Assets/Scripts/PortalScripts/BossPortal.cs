using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPortal : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string taskId;
    [SerializeField] private string bossSceneName;
    [SerializeField] private bool taskDone;
    [SerializeField] private Collider2D _collider;
    
    [SerializeField] private GameObject visualCue;
    
    private string npcStage;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                DataPersistenceManager.instance.SaveGame();
                SceneManager.LoadScene(bossSceneName);
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
    
    public void SaveTaskData(GameData data) { }

    public void LoadTaskData(GameData data)
    {
        data.tasksList.TryGetValue(taskId, out taskDone);
        data.npcStages.TryGetValue(taskId, out npcStage);
        if (!taskDone)
        {
            _collider.enabled = false;
        }
    }
    
    public void LoadKeyData(GameData data){}
    public void SaveKeyData(GameData data){}
    
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