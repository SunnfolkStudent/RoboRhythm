using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public Vector3 playerPosition;
    public Vector3 objectPosition;
    public bool hatOn;
    public bool hasAllKeys;
    public bool statueFixed;
    public bool lampsLit;

    public SerializableDictionary<string, string> npcStages;
    public SerializableDictionary<string, bool> tasksList;
    public SerializableDictionary<string, bool> keysFound;
    public SerializableDictionary<string, bool> statuePiecesFound;

    public GameData()
    {
        playerPosition = new Vector3(36, 58, 0);
        objectPosition = new Vector3(52.5f, 28, 0);
        hatOn = false;
        hasAllKeys = false;
        statueFixed = false;
        lampsLit = false;
        npcStages = new SerializableDictionary<string, string>();
        tasksList = new SerializableDictionary<string, bool>();
        keysFound = new SerializableDictionary<string, bool>();
        statuePiecesFound = new SerializableDictionary<string, bool>();
    }
}
