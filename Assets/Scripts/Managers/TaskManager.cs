using UnityEngine;

public class TaskManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string taskNpcId;
    [SerializeField] private string keyGotId;

    private bool falseKey = false;
    private string updatedTask;
    
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
        keyGotId = "";
    }
    
    public void LoadData(GameData data) { }

    public void SaveData(GameData data)
    {
        if(!string.IsNullOrEmpty(taskNpcId))
        {
            if (data.npcStages.ContainsKey(taskNpcId))
            {
                data.npcStages.Remove(taskNpcId);
            }
            data.npcStages.Add(taskNpcId, updatedTask);
        }
        if (taskNpcId == "Zither")
        {
            data.lampsLit = true;
        }
        
        if(!string.IsNullOrEmpty(keyGotId))
        {
            if (data.keysFound.ContainsKey(keyGotId))
            {
                data.keysFound.Remove(keyGotId, out falseKey);
            }

            data.keysFound.Add(keyGotId, true);
            keyGotId = "";
        }
    }
}
