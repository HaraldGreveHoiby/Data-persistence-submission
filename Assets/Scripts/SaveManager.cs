using System;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public string playerName;
    public string highScoreHolderName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScorer();
    }

    [Serializable]
    class SaveData
    {
        public string highScoreHolderName;
        public int highScore;
    }

    public void SaveHighScorer()
    {
        SaveData data = new SaveData();
        string highScoreHolderName = SaveManager.Instance.highScoreHolderName;
        int highScore = SaveManager.Instance.highScore;
        data.highScoreHolderName = highScoreHolderName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/high_scorer_save_data.json", json);
    }

    public void LoadHighScorer()
    {
        string path = Application.persistentDataPath + "/high_scorer_save_data.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreHolderName = data.highScoreHolderName;
        }
    }
}
