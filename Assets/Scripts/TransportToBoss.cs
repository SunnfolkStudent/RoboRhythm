using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransportToBoss : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string taskId;
    [SerializeField] private string bossSceneName;
    [SerializeField] private bool taskDone;
    [SerializeField] private Collider2D _collider;
    private string npcStage;

    private void Awake()
    {
        _collider.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E) && !taskDone)
        {
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadScene(bossSceneName);
        }
    }

    public void LoadData(GameData data)
    {
        data.tasksList.TryGetValue(taskId, out taskDone);
        data.npcStages.TryGetValue(taskId, out npcStage);
        if (npcStage == "First")
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
            _collider.enabled = true;
        }
        if (npcStage == "First" || npcStage == "")
        {
            _collider.enabled = false;
        }
    }
    
    public void LoadKeyData(GameData data){}
    public void SaveKeyData(GameData data){}
}
