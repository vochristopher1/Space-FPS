using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public Player player;

    void OnCollisionEnter(Collision collisionInfo) 
    {
        if (collisionInfo.collider.name == "Hurt")
        {
            player.TakeDamage(40);
        }
    }
}
