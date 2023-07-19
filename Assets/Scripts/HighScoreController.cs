using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreEntry
{
    public DateTime Time;
    public int Score;

    public ScoreEntry(DateTime time, int score)
    {
        Time = time;
        Score = score;
    }

    public static int SortByScore(ScoreEntry s1, ScoreEntry s2)
    {
        return -s1.Score.CompareTo(s2.Score);
    }
}

public class HighScoreController : MonoBehaviour
{
    public static HighScoreController Instance;
    private List<ScoreEntry> allScores = new List<ScoreEntry>();

    [SerializeField] ScoreBox[] highScoreBoxes;

    private void Awake()
    {
        Instance = this;
    }

    public void AddNewScore(int points)
    {
        allScores.Add(new ScoreEntry(System.DateTime.Now, points));
        allScores.Sort(ScoreEntry.SortByScore);
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < 4 ; i++)
        {
            if(allScores.Count > i)
            {
                highScoreBoxes[i].gameObject.SetActive(true);
                highScoreBoxes[i].UpdateTexts(allScores[i].Time, allScores[i].Score);
            }
            else
            {
                highScoreBoxes[i].gameObject.SetActive(false);
            }
        }
    }
}
