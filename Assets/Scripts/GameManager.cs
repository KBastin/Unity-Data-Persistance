using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class TopScore
    {
        public string Name;
        public int Score;
    }
    public string SaveLocation
    {
        get => Application.persistentDataPath + "/topscore.jscon";
    }


    public static GameManager Instance;
    public string UserName;
    public TopScore CurrentTopScore;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void HandleNewScore(int score)
    {
        if (CurrentTopScore is null || CurrentTopScore.Score < score)
        {
            CurrentTopScore = new TopScore() { Name = UserName, Score = score };
        }
    }

    private void SaveTopScore()
    {
        if (CurrentTopScore != null)
        {
            var json = JsonUtility.ToJson(CurrentTopScore);
            File.WriteAllText(SaveLocation, json);
        }
    }

    private void LoadTopScore()
    {
        if (File.Exists(SaveLocation))
        {
            var json = File.ReadAllText(SaveLocation);
            CurrentTopScore = JsonUtility.FromJson<TopScore>(json);
        }
    }
}
