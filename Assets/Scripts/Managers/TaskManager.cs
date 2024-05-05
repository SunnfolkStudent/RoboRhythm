using UnityEngine;

public class TaskManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string taskNpcId;
    [SerializeField] private string keyGotId;

    private bool falseKey = false;
    private string updatedTask;
    

    public void TaskComplete(string taskId)
    {
        taskNpcId = taskId;
        updatedTask = "Third";
        DataPersistenceManager.instance.SaveGame();
    }

    public void UpdateDialogue(string taskId)
    {
        taskNpcId = taskId;
        updatedTask = "Fourth";
        DataPersistenceManager.instance.SaveGame();
    }

    public void KeyObtained(string keyId)
    {
        keyGotId = keyId;
        DataPersistenceManager.instance.SaveGame();
    }
    
    public void LoadData(GameData data) { }

    public void SaveData(GameData data)
    {
        if(!string.IsNullOrEmpty(taskNpcId))
        {
            if (data.tasksList.ContainsKey(taskNpcId))
            {
                data.tasksList.Remove(taskNpcId);
            }
            data.tasksList.Add(taskNpcId, true);
            
            if (data.npcStages.ContainsKey(taskNpcId))
            {
                data.npcStages.Remove(taskNpcId);
            }
            data.npcStages.Add(taskNpcId, updatedTask);
        }
        
        if(!string.IsNullOrEmpty(keyGotId))
        {
            if (data.keysFound.ContainsKey(keyGotId))
            {
                data.keysFound.Remove(keyGotId, out falseKey);
            }

            data.keysFound.Add(keyGotId, true);
            keyGotId = "";
            updatedTask = "";
            taskNpcId = "";
        }
    }
}
