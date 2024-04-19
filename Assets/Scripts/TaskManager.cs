using UnityEngine;

public class TaskManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string tasknpcId;
    
    private static TaskManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Puzzle Manager in scene");
        }
        instance = this;
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
}
