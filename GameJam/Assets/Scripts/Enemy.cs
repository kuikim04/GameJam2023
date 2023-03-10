using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static float hp = 2;
    public Animator anim;
    float Dmg = 0.5f;

    public void Update()
    {
        if(hp <= 0)
        {
            anim.SetTrigger("dead");
            StartCoroutine(Dead());
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) ControlPlayer.TakeDamage(Dmg);

    }
  
    public static void TakeDamgeByPlayer(float DmgPlayer)
    {
        hp -= DmgPlayer;
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);      
        
    }
}
