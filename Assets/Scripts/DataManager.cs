using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Rendering.DebugUI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private string playerName;
    private int bestScore;
    private string bestPlayerName;

    public string PlayerName 
    {  
        get { return playerName; } 
        set 
        { 
            playerName = value; 
            Debug.Log("Name: " + playerName); 
        } 
    }
    public int BestScore { get { return bestScore; } }
    public string BestPlayerName { get { return bestPlayerName; } }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }         

        Instance = this;
        DontDestroyOnLoad(gameObject);

        playerName = "";
        bestPlayerName = "none";
        bestScore = 0;

        LoadAllData();
    }

    public void SetBestScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            bestPlayerName = playerName;
            SaveAllData();
        }
    }

    [Serializable]
    public class SaveData
    {
        public string BestPlayerName;
        public int BestScore;
    }

    public void SaveAllData()
    {
        var data = new SaveData();
        data.BestPlayerName = bestPlayerName;
        data.BestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile", json);
    }

    public void LoadAllData()
    {
        string path = Application.persistentDataPath + "/savefile";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.BestPlayerName;
            bestScore = data.BestScore;
        }
    }
}
