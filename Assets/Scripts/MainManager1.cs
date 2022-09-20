using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager1 : MonoBehaviour
{
    public static MainManager1 Instance;
    public string playerName;
    public int score;

    public string highscorePlayerName = "";
    public int highscore = 0;

    //To Do - determine new high score, add saving / loading. Variables are split w/ MainManager


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void SaveHighScore()
    {
        PlayerData highScoreData = new PlayerData();
        highScoreData.playerName = playerName;
        highScoreData.score = score;

        string json = JsonUtility.ToJson(highScoreData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData loadData = JsonUtility.FromJson<PlayerData>(json);

            highscorePlayerName = loadData.playerName;
            highscore = loadData.score;
        }

    }

    [Serializable] public class PlayerData
    {
        public string playerName;
        public int score;
    }

}
