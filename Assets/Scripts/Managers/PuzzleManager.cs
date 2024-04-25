using UnityEngine;

public class PuzzleManager : MonoBehaviour, IDataPersistence
{
    [Header("Task Id")] 
    [SerializeField] private string taskId;
    private bool taskDone;

    private void Start()
    {
        taskDone = false;
    }

    public void PuzzleOver()
    {
        taskDone = true;
        TaskManager.GetInstance().TaskComplete(taskId);
        DataPersistenceManager.instance.SaveGame();
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