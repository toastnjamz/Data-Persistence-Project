using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public GameObject inputField;
    
    public Text nameAndHighScoreText;
    public string playerName;
    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void NewNameEntered()
    {
        string text = inputField.GetComponent<TMP_InputField>().text;
        GameManager.Instance.currentPlayerName = text;
    }

    //TODO: create method to display name and high score
    
    public void SaveNameEntered()
    {
        GameManager.Instance.SaveName();
        // TODO: delete later?
    } 

    public void LoadNameEntered()
    {
        GameManager.Instance.LoadName();
        // TODO: delete later?
    }

    public void Exit()
    {
        GameManager.Instance.SaveName();
        //TODO: do I need this?
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
