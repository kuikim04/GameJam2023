using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerNotice : MonoBehaviour
{
    public GameObject btnNotice;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            btnNotice.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        btnNotice.SetActive(false);

    }
}
