using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataPersistence : MonoBehaviour
{

    public static DataPersistence Instance;

    public string nameField;
    public string bestPlayer;
    public int bestScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        bestScore = 0;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]

    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/saveFile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;
        }
    }
}
