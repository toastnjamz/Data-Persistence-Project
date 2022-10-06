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

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Start()
    {
        DisplayNameAndHighScore();
    }

    public void NewNameEntered()
    {
        string text = inputField.GetComponent<TMP_InputField>().text;
        GameManager.Instance.currentPlayerName = text;
    }

    private void DisplayNameAndHighScore()
    {
        GameManager.Instance.LoadNameAndScore();
        nameAndHighScoreText.text = "Best Score: " + GameManager.Instance.topPlayerName + " : " + GameManager.Instance.topHighScore;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
