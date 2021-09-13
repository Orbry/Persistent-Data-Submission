using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class HighscoreManager : Singleton<HighscoreManager>
{
    private string saveFileName = "highscores.json";
    private string saveFilePath;
    [SerializeField] private Highscore[] highscores;

    protected override void Awake()
    {
        base.Awake();
        saveFilePath = $"{Application.persistentDataPath}/{saveFileName}";
        highscores = new Highscore[10];
        LoadHighscores();
        DontDestroyOnLoad(gameObject);

        // TODO: delete
        Debug.Log($"Saves path -> {saveFilePath}");
        //MakeData();
        //SaveHighscores();
    }
    
    private void LoadHighscores()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            highscores = JsonHelper.FromJson<Highscore>(json);
            Array.Sort(highscores);
        }
    }
    
    private void SaveHighscores()
    {
        string json = JsonHelper.ToJson(highscores, true);
        File.WriteAllText(saveFilePath, json);
    }
    
    // TODO: delete
    private void MakeData()
    {
        string[] names = new[] { "John", "Mary", "Alex", "Joni", "Tyyne" };
        int[] scores = new[] { 10, 25, 13, 42, 30 };
        
        for (int i = 0; i < names.Length; i++) {
            highscores[i] = new Highscore(names[i], scores[i]);
        }
    }
    
    public void AddHighscore(string playerName, int score)
    {
        Highscore newHighscore = new Highscore(playerName, score);
        int insertionIndex = -1;
        
        for (int i = 0; i < highscores.Length; i++)
        {
            if (newHighscore > highscores[i] )
            {
                insertionIndex = i;
                break;
            }
        }

        if (insertionIndex >= 0)
        {
            Array.Copy(highscores, insertionIndex, highscores, insertionIndex + 1, highscores.Length - insertionIndex - 1);
            highscores[insertionIndex] = newHighscore;
        }
    }
}

[Serializable]
public class Highscore : IComparable<Highscore>
{
    [SerializeField] private string name;
    [SerializeField] private int score;
    
    public Highscore(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    // implementing IComparable<T> to allow to sort highscores via Array.sort();
    public int CompareTo(Highscore other)
    {
        if (other == null)
            return 1;

        // multiply by -1 to sort in DESC order, default is ASC
        return this.score.CompareTo(other.score) * -1;
    }
    
    public override string ToString() => $"{(name == "" ? "--/--": name)} {score}";

    // overloading to be able to compare to newly added highscore
    public static bool operator > (Highscore a, Highscore b) => a.score > b.score;
    public static bool operator < (Highscore a, Highscore b) => a.score < b.score;
}
