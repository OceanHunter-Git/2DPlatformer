using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    public Rigidbody2D theRb;

    public float moveSpeed;
    public float runSpeed;
    private float activeSpeed;

    public float jumpForce;

    private bool isGround;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public int jumpNumber;
    private int jumpNumberCount;

    public Animator playerAnim;

    public float knockBackTime;
    private float knockBackTimeCounter;
    public float knockBackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        jumpNumberCount = jumpNumber;    
    }

    // Update is called once per frame
    void Update()
    {

        if (knockBackTimeCounter <= 0)
        {
            activeSpeed = moveSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                activeSpeed = runSpeed;
            }
            theRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * activeSpeed, theRb.velocity.y);

            isGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
            
            if (isGround)
            {
                jumpNumberCount = jumpNumber - 1;
            }
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (isGround)
                {
                    Jump();
                }
                else
                {
                    if (jumpNumberCount > 0)
                    {
                        Jump();
                        jumpNumberCount--;
                        playerAnim.SetTrigger("isMoreJump");
                    }
                }
            }

            if (theRb.velocity.x >= 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            playerAnim.SetFloat("xSpeed", Mathf.Abs(theRb.velocity.x));
            playerAnim.SetFloat("ySpeed", theRb.velocity.y);
            playerAnim.SetBool("isGround", isGround);
        }
        else
        {
            knockBackTimeCounter -= Time.deltaTime;

            theRb.velocity = new Vector2(-knockBackSpeed * transform.localScale.x, theRb.velocity.y);
        }
    }

    public void Jump()
    {
        theRb.velocity = new Vector2(theRb.velocity.x, jumpForce);
    }

    public void KnockBack()
    {
        theRb.velocity = new Vector2(0f, jumpForce * 0.4f);
        knockBackTimeCounter = knockBackTime;
        playerAnim.SetTrigger("isKnockBack");
    }
}
