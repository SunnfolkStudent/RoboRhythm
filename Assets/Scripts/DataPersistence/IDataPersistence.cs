using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(GameData data);
    void SaveData(GameData data);
    
    /*void SaveTaskData(GameData data);
    void LoadTaskData(GameData data);

    void SaveKeyData(GameData data);
    void LoadKeyData(GameData data);*/
}
