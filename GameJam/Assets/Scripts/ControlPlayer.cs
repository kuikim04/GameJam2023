using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{

    private float horizontal;
    public float speed = 5;
    public float jumpPower = 10f;
    public float doubleJumpPower = 8f;
    private bool isFactingRight = true;



    private bool doubleJump;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Shoot System")]
    public Transform spawnBullet;
    public GameObject bullet;

    float curTime = 0;
    float startingTime = 3;
    bool canShoot = true;

    [Header("Anim")]
    public Animator playerAnim;

    [Header("Status Player")]
    public static float curHp;
    public float hp;

    public static float Dmg;
    public float atk;
    public PlayerStat stat;


    [Header("KnockBack")]
    [SerializeField] private Transform _center;
    [SerializeField] private float knockbackVel = 8f;
    [SerializeField] private bool knockbacked;
    [SerializeField] private float knockbackTime = 1;
    private SpriteRenderer _spriteRenderer;


    private void Start()
    {
        curTime = startingTime;

        curHp = PlayerData.instance.Hp(stat.HP) ;
        Dmg = PlayerData.instance.AtkDmg(stat.ATK);

        _spriteRenderer = GetComponent<SpriteRenderer>();


    }
    // Update is called once per frame
    void Update()
    {
     

        #region Status Player

        hp = curHp;
        atk = Dmg;

        #endregion

        
        horizontal = Input.GetAxisRaw("Horizontal");

        playerAnim.SetFloat("Speed", Mathf.Abs(horizontal));

        if(IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJump
                    ? doubleJumpPower : jumpPower);

                doubleJump = !doubleJump;
                SoundManager.Instance.PlaySfx("Jump");
            }
            //rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (!canShoot)
        {
            curTime -= 1 * Time.deltaTime;

            if (curTime <= 0)
            {
                canShoot = true;
                curTime = 3;

            }
        }

        if (canShoot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
                canShoot = false;
            }
        }

        Flip();
        ApplyMovement();

    }
    void ApplyMovement()
    {
        if(!knockbacked)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }else
        {
            var lerpedXVelocity = Mathf.Lerp(rb.velocity.x, 0f,Time.deltaTime * 3);
            rb.velocity = new Vector2(lerpedXVelocity,rb.velocity.y);
        }
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if(isFactingRight && horizontal < 0f || !isFactingRight && horizontal > 0f)
        {
            isFactingRight = !isFactingRight;
            transform.Rotate(0, 180, 0);
        }
    }

    public void KnockBack(Transform t)
    {
        var dir = _center.position - t.position;
        knockbacked = true;
        rb.velocity = (dir.normalized * knockbackVel);
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
        yield return new WaitForSeconds(knockbackTime);
        knockbacked = false;
    }

    public static void TakeDamage(float DmgEnemy)
    {
        curHp -= DmgEnemy;
    }
}
