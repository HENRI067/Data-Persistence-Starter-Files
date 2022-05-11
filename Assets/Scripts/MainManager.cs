using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// this script show the best score in the menu screen when the game starts & the last named that was used
/// 
/// </summary>

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private string playerName;
    private int playerScore;

    private int bestScore;
    private string bestPlayer;

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
        LoadBestScore();
    }








    ///<SaveFileHandler>
    [System.Serializable]
    class SaveData
    {
        public string lastName;
        public int lastScore;

        public string bestName;
        public int bestScore;
    }
    //method is called when player presses the "OK" button
    public void SavePlayerName()
    {

    }
    //save name is only called when the player beats the best score saved and loses in the game scene
    public void SaveBestScore()
    {
        if(FindSaveFile() == false)
        {
            SaveData data = new SaveData();
        }
    }
    //load name is only called when the player opens the game
    public void LoadBestScore() { }
    //checks to see if a savefile exist
    private bool FindSaveFile()
    {
        bool saveExists = false;

        string location = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(location)) saveExists = true;

        return saveExists;
    }
    /// </SaveFileHandler>
}
