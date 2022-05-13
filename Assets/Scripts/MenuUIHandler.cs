using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public static MenuUIHandler Instance;

    [SerializeField] public GameObject textInput;
    [SerializeField] public GameObject textDisplay;
    public string nameTyped;

    private void Awake()
    {
        //<Setup>
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        StartCoroutine(UISetup());
        // </Setup>
    }


    IEnumerator UISetup()
    {
        yield return new WaitForSeconds(0.1f);
        MainManager.Instance.LoadName();
    }

    public void SetName()
    {
        nameTyped = textInput.GetComponent<TMP_Text>().text;
        textDisplay.GetComponent<TMP_Text>().text = nameTyped;
        MainManager.Instance.playerName = nameTyped;
        MainManager.Instance.SaveName();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LeaveGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

}
