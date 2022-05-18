using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpponentScore : MonoBehaviour
{
    public float opponentScoreNum = 0;
    public TextMeshProUGUI opponentScoreText;

    void Start()
    {
        DisplayOpponentScore(opponentScoreNum);
    }

    public void Opponent()
    {
        if (opponentScoreNum == 2) 
        {
            opponentScoreNum++;
            DisplayOpponentScore(opponentScoreNum);
            FindObjectOfType<GameManager>().YouLose();
        }
        else 
        {
            opponentScoreNum++;
            DisplayOpponentScore(opponentScoreNum);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void DisplayOpponentScore(float opponentScoreNum)
    {
        opponentScoreText.text = string.Format("{0}", opponentScoreNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
