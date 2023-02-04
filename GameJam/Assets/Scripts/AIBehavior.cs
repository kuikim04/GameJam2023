using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private Rigidbody2D myRb;
    private BoxCollider2D myBoxColider;


    public float KnockBackForce = 10;
    public float KnockBackTime = 2;
    public Transform _center;
    private SpriteRenderer _spriteRenderer;

    bool knockBack = false;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        myBoxColider = GetComponent<BoxCollider2D>();

        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!knockBack)
        {

            if (IsFacingRight())
            {
                transform.rotation = Quaternion.Euler(0, 0, 5);
                myRb.velocity = new Vector2(moveSpeed, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, -5);
                myRb.velocity = new Vector2(-moveSpeed, 0f);

            }
        }
    }

    public void KnockBacked(Transform t)
    {
        var dir = _center.position - t.position;
        knockBack = true;
        myRb.velocity = (dir.normalized * KnockBackForce);
        _spriteRenderer.color = Color.red;

        StartCoroutine(CancleKnockBack());
        StartCoroutine(FadeToWhite());
    }

    IEnumerator FadeToWhite()
    {
        while (_spriteRenderer.color != Color.white)
        {
            yield return null;
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Color.white, Time.deltaTime * 3);
        }
    }


    IEnumerator CancleKnockBack()
    {
        yield return new WaitForSeconds(KnockBackTime);
        knockBack = false;
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
