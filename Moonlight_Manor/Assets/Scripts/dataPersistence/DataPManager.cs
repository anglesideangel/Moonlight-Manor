using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPManager : MonoBehaviour
{
    [Header("File storage config")]
    [SerializeField]private string filename;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPManager instance {get;private set;}
    private void Awake(){
        if(instance != null){
            Debug.LogError("More than one instance");
        }
        instance = this;

    }

    private void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath,filename); 
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){
        //TODO: load game
        this.gameData = dataHandler.Load();

        if(this.gameData == null){
            Debug.Log("No game found, New game will be started");
            NewGame();
        }
        foreach(IDataPersistence DPO in dataPersistenceObjects){
            DPO.LoadData(gameData);
        }
        //TODO: push loaded data
    }

    public void SaveGame(){
        //TODO:pass data to other scripts
        //TODO:pass data to save file
        foreach(IDataPersistence DPO in dataPersistenceObjects){
            DPO.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }

    private void OnAppQuit(){
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
