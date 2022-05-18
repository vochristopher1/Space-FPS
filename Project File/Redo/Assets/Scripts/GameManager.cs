using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameOverScreen GameOverScreen;
    public PlayerScore playerScore;
    public OpponentScore opponentScore;
    public Player playerHealth;
    public Target opponentHealth;

    void Start() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void TimeUp()
    {
        if (playerHealth.currentHealth > opponentHealth.health)
        {
            FindObjectOfType<PlayerScore>().Player();

        }
        else if (playerHealth.currentHealth < opponentHealth.health)
        {
            FindObjectOfType<OpponentScore>().Opponent();
        }
        else
        {
            Tie();
        }
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    public void EndGame()
    {
        if (gameHasEnded == false) 
        {
            gameHasEnded = true;
            Debug.Log("GameOver");
            Invoke("Restart", restartDelay);
        }
    }

    public void Tie() 
    {
        if (gameHasEnded == false) 
        {
            gameHasEnded = true;
            Debug.Log("Tie");
            Invoke("Restart", restartDelay);
        }
    }

    public void YouWin()
    {
        Debug.Log("You Win");
        FindObjectOfType<PlayerScore>().Reset();
        SceneManager.LoadScene(3);
    }

    public void YouLose()
    {
        Debug.Log("You Lose");
        SceneManager.LoadScene(3);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
