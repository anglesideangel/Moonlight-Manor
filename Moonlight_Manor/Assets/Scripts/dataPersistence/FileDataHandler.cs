using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";
    public FileDataHandler(string dataDirPath,string dataFileName){
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }
    public GameData Load(){
        string fullPath = Path.Combine(dataDirPath,dataFileName);
        GameData LoadedData = null;
        if(File.Exists(fullPath)){
            try{
                string dataToload = "";
                using (FileStream stream = new FileStream(fullPath,FileMode.Open)){
                    using (StreamReader reader = new StreamReader(stream)){
                        dataToload = reader.ReadToEnd();
                    }
                }
                LoadedData = JsonUtility.FromJson<GameData>(dataToload);
            }
            catch(Exception err){
                Debug.LogError("Error loading file: " + fullPath + "\n" + err);
            }
        }
        return LoadedData;
    }
    public void Save(GameData data){
        string fullPath = Path.Combine(dataDirPath,dataFileName);
        try{
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string storeData = JsonUtility.ToJson(data);
            using (FileStream stream = new FileStream(fullPath,FileMode.Create)){
                using (StreamWriter writer  = new StreamWriter(stream)){
                    writer.Write(storeData);
                }
            }
        }
        catch(Exception err){
            Debug.LogError("Error occurred while saving: " + fullPath + "\n" + err);
        }
    }
}
