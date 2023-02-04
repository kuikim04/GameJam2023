using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDmgEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.collider.GetComponent<AIBehavior>();

        if (enemy != null)
        {
            enemy.KnockBacked(transform);
            Destroy(gameObject);
            Enemy.TakeDamgeByPlayer(ControlPlayer.Dmg);
        }
        else
        {
            Destroy(gameObject, 5f);
        }
    }
 
}
