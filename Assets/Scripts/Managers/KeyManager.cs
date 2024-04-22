using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string keyId;
    [SerializeField] private bool keyObtained = false;
    [SerializeField] private Image image;

    private static KeyManager instance;

   /* private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Key Manager in scene!");
        }

        instance = this;
    }*/

    /*public static KeyManager GetInstance()
    {
        return instance;
    }*/

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void KeyObtained(string keyId)
    {
        image.enabled = true;
    }

    public void LoadData(GameData data)
    {
        data.keysFound.TryGetValue(keyId, out keyObtained);
        if (keyObtained)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }

    public void SaveData(GameData data)
    {
        if (data.keysFound.ContainsKey(keyId))
        {
            data.keysFound.Remove(keyId, out keyObtained);
        }
        data.keysFound.Add(keyId, keyObtained);
    }
    
    public void SaveTaskData(GameData data) { }

    public void LoadTaskData(GameData data) { }

    public void LoadKeyData(GameData data)
    {
        data.keysFound.TryGetValue(keyId, out keyObtained);
        if (keyObtained)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
    public void SaveKeyData(GameData data){}
}
