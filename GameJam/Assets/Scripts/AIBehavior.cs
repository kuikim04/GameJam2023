using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private Rigidbody2D myRb;
    private BoxCollider2D myBoxColider;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        myBoxColider = GetComponent<BoxCollider2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            myRb.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRb.velocity = new Vector2(-moveSpeed, 0f);

        }
    }

    bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRb.velocity.x)),
            transform.localScale.y);

    }
}
