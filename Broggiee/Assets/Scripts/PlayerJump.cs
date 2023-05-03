using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float jumpingPower;
    private bool isFacingRight = true;
    public bool IsGrounded;

    private bool isJumping;

    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;

    private Animator anim;//for animation

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool canJump = false;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            Debug.Log(IsGrounded);
            canJump = true;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") )//|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            
            jumpBufferCounter = jumpBufferTime;
            
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
            anim.SetBool("Jump", false);
        }

        if (canJump && coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.SetBool("Jump", true);
            jumpBufferCounter = 0f;
            canJump = false;
            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
            //for animation
            anim.SetBool("Jump", true);
        }
        //for animation
        if (horizontal > 0f)
        {
            anim.SetBool("Run", true);
        }
        else if (horizontal <0f)
        {
            anim.SetBool("Run", true);
        }
        else 
        {
            anim.SetBool("Run", false);
        }//till this

        //for animation
     // if (speed > 0f)
     // {
     //    anim.SetBool("Jump", true);
     // }
     // else if (speed <0f)
     // {
     //    anim.SetBool("Jump", true);
     // }
     // else 
     // {
     //    anim.SetBool("Jump", false);
     // }
        //till this


        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    // private bool IsGrounded()
    // {
    //     bool grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    //     Debug.Log(grounded);
    //     return grounded;
    // }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.8f);
        isJumping = false;
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("BreakableBlock"))
        {
            IsGrounded=true;
        }
        else IsGrounded=false;
    }
}