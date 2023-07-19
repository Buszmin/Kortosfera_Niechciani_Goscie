using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreBox : MonoBehaviour
{
    [SerializeField] TextMeshPro pointsText;
    [SerializeField] TextMeshPro timeText;

    public void UpdateTexts(DateTime time, int point)
    {
        pointsText.text = point.ToString();
        string dayTime = time.TimeOfDay.ToString();
        timeText.text = dayTime.Substring(0, dayTime.Length - 11);
    }
}
