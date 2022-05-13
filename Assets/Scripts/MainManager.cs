using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
/// <summary>
/// this script show the best score in the menu screen when the game starts & the last named that was used
/// 
/// </summary>

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string playerName;
    public int bestScore;
    public string bestPlayer;

    private void Awake()
    {
        //<Setup>
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        // </Setup>
        LoadName();
        GetBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestName;
        public int bestScore;
        public string lastName;
    }
    public void SaveName()
    {
        SaveData data = GetData();
        MenuUIHandler.Instance.nameTyped = playerName;
        data.lastName = playerName;
        SaveTheData(data);
    }
    public void LoadName()
    {
        SaveData data = GetData();
        playerName = data.lastName;
        MenuUIHandler.Instance.textDisplay.GetComponent<TMP_Text>().text = data.lastName;
    }
    public void SaveBestScore(int score)
    {
        bestPlayer = playerName;

        SaveData data = GetData();
        data.bestName = playerName;
        data.bestScore = score;
        SaveTheData(data);
        GetBestScore();
    }
    //Updates the best score values on this script on startup and when the player beats the last score
    private void GetBestScore()
    {
        SaveData data = GetData();
        bestPlayer = data.bestName;
        bestScore = data.bestScore;
    }


    //Save SaveData to .json
    private void SaveTheData(SaveData data)
    {
        string dataPath = Application.persistentDataPath + "/savefile.json";

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(dataPath, json);
    }
    //Get SaveData from .json
    private SaveData GetData()
    {
        SaveData data = null;
        string dataPath = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(dataPath))
        {
            string json = File.ReadAllText(dataPath);
            data = JsonUtility.FromJson<SaveData>(json);
        }
        else if (File.Exists(dataPath) == false)
        {
            data = new SaveData();
            data.bestName = "the Noob";
            data.bestScore = 0;
            data.lastName = playerName;

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        return data;
    }

}
