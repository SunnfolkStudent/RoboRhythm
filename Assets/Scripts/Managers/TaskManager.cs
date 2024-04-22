using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaskManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string tasknpcId;
    [SerializeField] private string keyGotId;

    private bool falseKey = false;
    
    private static TaskManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Task Manager in scene");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    public static TaskManager GetInstance()
    {
        return instance;
    }

    public void TaskComplete(string taskId)
    {
        tasknpcId = taskId;
        DataPersistenceManager.instance.SaveTaskData();
    }

    public void KeyObtained(string keyId)
    {
        keyGotId = keyId;
        DataPersistenceManager.instance.SaveKeyData();
    }
    
    public void LoadData(GameData data) { }

    public void SaveData(GameData data) { }
    
    public void SaveTaskData(GameData data)
    { 
        if (data.npcStages.ContainsKey(tasknpcId))
        {
            data.npcStages.Remove(tasknpcId);
        }

        data.npcStages.Add(tasknpcId, "Third");
        Debug.Log("add new stage to npc");
    }
    public void LoadTaskData(GameData data) { }
    
    public void LoadKeyData(GameData data){}

    public void SaveKeyData(GameData data)
    {
        if (data.keysFound.ContainsKey(keyGotId))
        {
            data.keysFound.Remove(keyGotId, out falseKey);
        }
        if(keyGotId != "")
        {
            data.keysFound.Add(keyGotId, true);
        }
        Debug.Log("Set key: " + keyGotId + " to true");
    }
}
