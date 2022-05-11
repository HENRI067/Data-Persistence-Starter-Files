using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// this script show the best score in the menu screen when the game starts & the last named that was used
/// 
/// </summary>

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string playerName;
    private int bestScore;
    private string bestPlayer;

    private string nameTyped;
    [SerializeField] private GameObject textInput;
    [SerializeField] private GameObject textDisplay;



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
        nameTyped = textInput.GetComponent<TMP_Text>().text;
        textDisplay.GetComponent<TMP_Text>().text = nameTyped;
        playerName = nameTyped;

        SaveData data = GetData();
        data.lastName = playerName;
        SaveTheData(data);
    }
    public void LoadName()
    {
        SaveData data = GetData();
        playerName = data.lastName;
        textDisplay.GetComponent<TMP_Text>().text = data.lastName;
    }
    private void GetBestScore()
    {
        SaveData data = GetData();
        bestPlayer = data.bestName;
        bestScore = data.bestScore;
    }


    //[SaveToJson]/[getSaveFromJson]
    private void SaveTheData(SaveData data)
    {
        string dataPath = Application.persistentDataPath + "/savefile.json";

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(dataPath, json);
    }
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
