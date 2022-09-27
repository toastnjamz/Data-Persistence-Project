using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    private string nameInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadTextInput(string name)
    {
        nameInput = name;
        Debug.Log(nameInput);
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
