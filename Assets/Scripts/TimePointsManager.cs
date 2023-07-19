using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimePointsManager : MonoBehaviour
{
    public static TimePointsManager Instance;
    private int allPoints;
    [SerializeField] private float timeStart = 60;
    private float timeRemaining;
    private bool timerIsRunning = false;
    [SerializeField] private TextMeshPro timeText;
    [SerializeField] private TextMeshPro pointText;
    [SerializeField] private TextMeshPro pointTextEndScreen;

    [SerializeField] private GameObject activePanel;
    [SerializeField] private GameObject nextPanel;
    [SerializeField] private Transform bacteriaSpanwer;
    [SerializeField] private Animation anim;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        timerIsRunning = true;
        allPoints = 0;
        UpdatePoints(0);
        timeRemaining = timeStart;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;

                StartCoroutine(waitForAnim());
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

     public void UpdatePoints(int newPoints)
    {
        allPoints += newPoints;
        pointText.text = allPoints.ToString();
        pointTextEndScreen.text = allPoints.ToString();
    }

    IEnumerator waitForAnim()
    {
        yield return new WaitForSeconds(0.24f);

        activePanel.SetActive(false);
        HighScoreController.Instance.AddNewScore(allPoints);
        nextPanel.SetActive(true);

        while (bacteriaSpanwer.childCount > 0)
        {
            DestroyImmediate(bacteriaSpanwer.GetChild(0).gameObject);
        }
    }
}
