using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Debugging")] 
    [SerializeField] private bool initializeDataIfNull = false;
    
    [Header("File Storage Config")] 
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;
    
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        
        DontDestroyOnLoad(this.gameObject);
        
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    
    public void LoadGame()
    {
        // load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        if (this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        if (this.gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded.");
            return;
        }

        foreach (IDataPersistence dataPersistenceOBJ in dataPersistenceObjects)
        {
            dataPersistenceOBJ.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        if (this.gameObject == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }
        
        foreach (IDataPersistence dataPersistenceOBJ in dataPersistenceObjects)
        {
            dataPersistenceOBJ.SaveData(gameData);
        }
        
        // save that data to a file using the data handler
        dataHandler.Save(gameData);
    }
    
    /*public void SaveTaskData()
    {
        if (this.gameObject == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }
        
        foreach (IDataPersistence dataPersistenceOBJ in dataPersistenceObjects)
        {
            dataPersistenceOBJ.SaveTaskData(gameData);
        }
        
        // save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    public void LoadTaskData()
    {
        // load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        if (this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        if (this.gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded.");
            return;
        }

        foreach (IDataPersistence dataPersistenceOBJ in dataPersistenceObjects)
        {
            dataPersistenceOBJ.LoadTaskData(gameData);
        }
    }

    public void SaveKeyData()
    {
        if (this.gameObject == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }
        
        foreach (IDataPersistence dataPersistenceOBJ in dataPersistenceObjects)
        {
            dataPersistenceOBJ.SaveKeyData(gameData);
        }
        
        // save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    public void LoadKeyData()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        if (this.gameData == null)
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded.");
            return;
        }

        foreach (IDataPersistence dataPersistenceOBJ in dataPersistenceObjects)
        {
            dataPersistenceOBJ.LoadKeyData(gameData);
        }
    }*/

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
          IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}
