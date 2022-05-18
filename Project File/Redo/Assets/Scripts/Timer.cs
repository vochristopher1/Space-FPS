using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public TextMeshProUGUI timerText;

    void Start() 
    {
        countDownTimer();
    }

    void countDownTimer()
    {
        if (timeValue > 0)
        {
            timeValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else 
        {
            timeValue = 0;
            FindObjectOfType<GameManager>().TimeUp();
        }
        
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
