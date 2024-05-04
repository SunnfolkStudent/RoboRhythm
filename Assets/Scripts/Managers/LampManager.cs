using UnityEngine;

public class LampManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject litLamps;
    [SerializeField] private GameObject unlitLamps;
    private bool isLit;
    private bool taskDone;

    private void Update()
    {
        if (isLit)
        {
            litLamps.SetActive(true);
            unlitLamps.SetActive(false);
        }
        else
        {
            litLamps.SetActive(false);
            unlitLamps.SetActive(true);
        }
    }

    public void LoadData(GameData data)
    {
        data.tasksList.TryGetValue("Zither", out taskDone);
        if(taskDone)
        {
            isLit = true;
        }
        else
        {
            isLit = data.lampsLit;
        }
    }
    public void SaveData(GameData data)
    {
        data.lampsLit = isLit;
    }
}
