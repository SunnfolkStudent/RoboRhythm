using UnityEngine;

public class LampManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject litLamps;
    private bool isLit;

    private void Update()
    {
        if (isLit)
        {
            litLamps.SetActive(true);
        }
        else
        {
            litLamps.SetActive(false);
        }
    }

    public void LoadData(GameData data)
    {
        isLit = data.lampsLit;
    }
    public void SaveData(GameData data)
    {
        data.lampsLit = isLit;
    }
    public void SaveTaskData(GameData data) { }
    public void LoadTaskData(GameData data) { }
    public void LoadKeyData(GameData data) { }
    public void SaveKeyData(GameData data) { }
}
