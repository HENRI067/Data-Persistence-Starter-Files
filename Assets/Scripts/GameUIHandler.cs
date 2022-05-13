using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        // </Setup>
        StartCoroutine(UISetup());
    }

    public void UpdateBestScore(int score)
    {
        bestScoreText.text = $"Best Score :{MainManager.Instance.bestPlayer}[{MainManager.Instance.bestScore}]";
    }

    IEnumerator UISetup()
    {
        yield return new WaitForSeconds(0.1f);
        scoreText.text = $"Score : {MainManager.Instance.playerName}[0]";
        bestScoreText.text = $"Best Score :{MainManager.Instance.bestPlayer}[{MainManager.Instance.bestScore}]";
    }











    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
