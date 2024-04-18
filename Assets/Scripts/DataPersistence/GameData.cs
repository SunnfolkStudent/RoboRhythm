using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    //public Vector3 playerPosition;

    public SerializableDictionary<string, string> npcStages;
    public SerializableDictionary<string, bool> tasksList;
    public SerializableDictionary<string, bool> keysFound;

    public GameData()
    {
        //playerPosition = Vector3.zero;
        npcStages = new SerializableDictionary<string, string>();
        tasksList = new SerializableDictionary<string, bool>();
        keysFound = new SerializableDictionary<string, bool>();
    }
}
