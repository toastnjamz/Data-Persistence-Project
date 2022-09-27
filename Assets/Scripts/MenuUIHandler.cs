using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public GameObject inputField;

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
        GameManager.Instance.playerName = text;
    }

    public void SaveNameEntered()
    {
        GameManager.Instance.SaveName();
    } 

    public void LoadNameEntered()
    {
        GameManager.Instance.LoadName();
    }

    public void Exit()
    {
        GameManager.Instance.SaveName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
