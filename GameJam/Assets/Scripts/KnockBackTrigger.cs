using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<ControlPlayer>();

        if(player != null)
        {
            player.KnockBack(transform);
        }
    }
}
