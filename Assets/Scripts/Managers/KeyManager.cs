using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string keyId;
    [SerializeField] private bool keyObtained;
    private SpriteRenderer _spriteRenderer;

    private static KeyManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Key Manager in scene!");
        }

        instance = this;
    }

    public static KeyManager GetInstance()
    {
        return instance;
    }

    public void KeyObtained(string keyId)
    {
        _spriteRenderer.enabled = true;
    }

    public void LoadData(GameData data)
    {
        data.keysFound.TryGetValue(keyId, out keyObtained);
        if (keyObtained)
        {
            _spriteRenderer.enabled = true;
        }
        else
        {
            _spriteRenderer.enabled = false;
        }
    }

    public void SaveData(GameData data)
    {
        if (data.keysFound.ContainsKey(keyId))
        {
            data.keysFound.Remove(keyId);
        }
        data.keysFound.Add(keyId, keyObtained);
    }
    
    public void SaveTaskData(GameData data) { }
    public void LoadTaskData(GameData data) { }
}
