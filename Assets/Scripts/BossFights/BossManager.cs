using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour, IDataPersistence
{
    [Header("Task Id")] 
    [SerializeField] private string taskId;
    [SerializeField] private bool taskDone;
    
    private static BossManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Key Manager in scene!");
        }

        instance = this;
    }

    public static BossManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        taskDone = false;
    }

    public void BossOver()
    {
        taskDone = true;
        TaskManager.GetInstance().TaskComplete(taskId);
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene("PlayTestScene");
    }
    
    public void LoadData(GameData data)
    {
        data.tasksList.TryGetValue(taskId, out taskDone);
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
    
    public void LoadKeyData(GameData data){}
    public void SaveKeyData(GameData data){}
}
