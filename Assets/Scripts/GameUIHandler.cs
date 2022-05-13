using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameUIHandler : MonoBehaviour
{
    public static GameUIHandler Instance;

    public Text bestScoreText;
    public Text scoreText;


    public void Awake()
    {
        //<Setup>
        if (Instance != null)
        {
            Destroy(this.gameObject);
            
        }
        Instance = this;
        // </Setup>
        UISetup();
    }

    public void UpdateBestScore(int score)
    {
        bestScoreText.text = $"Best Score :{MainManager.Instance.bestPlayer}[{MainManager.Instance.bestScore}]";
    }


    private void UISetup()
    {
        scoreText.text = $"Score : {MainManager.Instance.playerName}[0]";
        bestScoreText.text = $"Best Score :{MainManager.Instance.bestPlayer}[{MainManager.Instance.bestScore}]";
    }











    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
