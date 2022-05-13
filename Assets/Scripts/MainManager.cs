using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using TMPro;

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
        data.lastName = playerName;

        MenuUIHandler.Instance.nameTyped = playerName;
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
