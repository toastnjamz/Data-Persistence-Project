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
            Debug.Log("File path exists, loading data");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            if (data.playerNameToSave == null)
            {
                topPlayerName = "";
                topHighScore = 0;
            }
            else
            {
                topPlayerName = data.playerNameToSave;
                topHighScore = data.playerHighScoreToSave;
            }
        }
    }
}
