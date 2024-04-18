using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(GameData data);
    void SaveData(GameData data);
    
    void SavePuzzleData(GameData data);
    void LoadPuzzleData(GameData data);
}
