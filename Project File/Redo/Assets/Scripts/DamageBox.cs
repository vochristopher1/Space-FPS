using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBox : MonoBehaviour
{
    public Player player;

    public void OnCollision(Collision col) 
    {
        if (col.gameObject.tag == "Player")
        {
            player.TakeDamage(20);
        }
    }
}
