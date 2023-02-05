using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endUi;
    public GameObject btn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            endUi.SetActive(true);
        }
    }
    IEnumerator showBtn()
    {
        yield return new WaitForSeconds(2);

        btn.SetActive(true);
    }
}
