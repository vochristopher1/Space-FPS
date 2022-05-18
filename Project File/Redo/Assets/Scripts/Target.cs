using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public int numEnemies = 3;
    public checkEnemies check;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die() 
    {
        Destroy(gameObject);
        FindObjectOfType<checkEnemies>().check();
    }
}
