using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static float hp = 2;
    float Dmg = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) ControlPlayer.TakeDamage(Dmg);

    }
  
    public static void TakeDamgeByPlayer(float DmgPlayer)
    {
        hp -= DmgPlayer;
    }
}
