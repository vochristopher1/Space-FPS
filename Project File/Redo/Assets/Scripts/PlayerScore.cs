using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public float playerScoreNum = 0;
    public TextMeshProUGUI playerScoreText;

    void Start()
    {
        DisplayPlayerScore(playerScoreNum);
    }

    public void Player()
    {
        if (playerScoreNum == 2) 
        {
            playerScoreNum++;
            DisplayPlayerScore(playerScoreNum);
            FindObjectOfType<GameManager>().YouWin();
        }
        else 
        {
            playerScoreNum++;
            DisplayPlayerScore(playerScoreNum);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void Reset() 
    {
        playerScoreNum = 0;
        //Invoke("DisplayPlayerScore", 1.0f);
    }

    void DisplayPlayerScore(float playerScoreNum)
    {
        playerScoreText.text = string.Format("{0}", playerScoreNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
