using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInfo : MonoBehaviour
{
    public static UserInfo Instance;

    [SerializeField] private GameObject playerNameText;

    public string playerName;
    public string recordPlayerName;
    public int bestScore;

    private void Awake()
    {
        //bestScore = 0;

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GetPlayerName()
    {
        if (playerNameText.GetComponent<TMP_InputField>().text != "")
        {
            playerName = playerNameText.GetComponent<TMP_InputField>().text;
        }
        else
        {
            playerName = "NULL";
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);
        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Akama Software/Brick Hero");
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Akama Software/Brick Hero" + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Akama Software/Brick Hero" + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            recordPlayerName = data.playerName;
            bestScore = data.score;
        }
    }

}
