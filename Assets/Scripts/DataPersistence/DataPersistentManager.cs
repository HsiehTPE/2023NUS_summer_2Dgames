using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistentManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField] private string fileName;

    private GameData gameData; 

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler  dataHandler;

    public static DataPersistentManager instance {get; private set;}



    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Error!\n More than one!\n");
        }
        instance = this;
    }
    


    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath,fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        this.gameData = new GameData();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)) LoadGame();
        if(Input.GetKeyDown(KeyCode.B)) SaveGame();
    }



    public void NewGame()
    {
        this.gameData = new GameData();
    }



    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if(this.gameData == null){
            Debug.Log("No game founded! Load a new game.\n");
            NewGame();
        }

        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

    }



    public void SaveGame()
    {
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }


        dataHandler.Save(gameData);

    }



    private void OnApplicationQuit()
    {
        SaveGame();
    }



    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}
