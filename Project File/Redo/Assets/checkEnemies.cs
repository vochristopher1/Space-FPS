using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkEnemies : MonoBehaviour
{
    public int numEnemies = 3;
    public void check()
    {
        numEnemies--;
        if (numEnemies <= 0)
        {
            FindObjectOfType<PlayerScore>().Player();
        }
    }
}
