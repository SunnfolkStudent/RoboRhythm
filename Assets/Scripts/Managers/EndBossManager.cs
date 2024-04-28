using System;
using UnityEngine;
using UnityEngine.UI;

public class EndBossManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Image key1, key2, key3, key4, key5, key6;
    private bool allKeysFound;
    private Image completeKeysImage;
    
    private void Start()
    {
        completeKeysImage = GetComponent<Image>();
        completeKeysImage.enabled = false;
        allKeysFound = false;
    }

    private void Update()
    {
        if (!key1.enabled) return;
        if (!key2.enabled) return;
        if (!key3.enabled) return;
        if (!key4.enabled) return;
        if (!key5.enabled) return;
        if (!key6.enabled) return;
        completeKeysImage.enabled = true;
        allKeysFound = true;
    }

    public void LoadData(GameData data)
    {
        allKeysFound = data.hasAllKeys;
    }

    public void SaveData(GameData data)
    {
        data.hasAllKeys = allKeysFound;
    }
    
    public void SaveTaskData(GameData data) { }

    public void LoadTaskData(GameData data) { }

    public void LoadKeyData(GameData data)
    {
        allKeysFound = data.hasAllKeys;
    }

    public void SaveKeyData(GameData data)
    {
        data.hasAllKeys = allKeysFound;
    }
}
