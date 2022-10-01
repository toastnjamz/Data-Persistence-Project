using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string currentPlayerName;
    public string topPlayerName;
    public int topHighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerNameToSave;
        public int playerHighScoreToSave;
    }

    public void SaveName()
    {
        // destroy later?
    }

    public void LoadName()
    {
        // destroy later?
    }

    public void SaveNameAndScore(string name, int score)
    {
        SaveData data = new SaveData();
        data.playerNameToSave = name;
        data.playerHighScoreToSave = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            topPlayerName = data.playerNameToSave;
            topHighScore = data.playerHighScoreToSave;
        }
        else
        {
            topPlayerName = "";
            topHighScore = 0;
        }
    }
}
