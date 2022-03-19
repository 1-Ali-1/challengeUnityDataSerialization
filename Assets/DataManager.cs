using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName = "no one";
    public int highestScore = 0;
    public string highestScorePlayer;
    // Start is called before the first frame update
 void Awake(){
     if(Instance != null){
         Destroy(gameObject);
         return;
     }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighest();
 }

 [System.Serializable]
class SaveData
{
    public int highestScore;
    public string highestScorePlayer;
}


public void SaveHighest()
{
    SaveData data = new SaveData();
    data.highestScore = highestScore;
    data.highestScorePlayer = highestScorePlayer;

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

public void LoadHighest()
{
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        highestScorePlayer = data.highestScorePlayer;
        highestScore = data.highestScore;
    }
}




}
