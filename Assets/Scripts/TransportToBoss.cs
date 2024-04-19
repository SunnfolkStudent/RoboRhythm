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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadScene(bossSceneName);
        }
    }

    public void LoadData(GameData data)
    {
        data.tasksList.TryGetValue(taskId, out taskDone);
        if (!taskDone)
        {
            _collider.enabled = true;
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
    public void LoadTaskData(GameData data) { }
}
