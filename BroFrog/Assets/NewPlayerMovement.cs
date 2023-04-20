using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    // Movement variables
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float coyoteTime = 0.2f;
    public float jumpBufferTime = 0.1f;

    // Jump variables
    private bool isJumping = false;
    private bool jumpBuffered = false;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    // Ground check variables
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;
    private bool isGrounded;

    // Rigidbody2D and Animator components
    private Rigidbody2D rb;
    //private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // Handle horizontal movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        // Flip player sprite depending on direction
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // Handle jump input and coyote time
        if (Input.GetKeyDown(KeyCode.Space)&&(isGrounded==true))
        {
            jumpBuffered = true;
            jumpBufferCounter = jumpBufferTime;
        }

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            //anim.SetBool("isJumping", false);
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            //anim.SetBool("isJumping", true);
        }

        if (jumpBuffered && coyoteTimeCounter > 0f)
        {
            jumpBuffered = false;
            Jump();
        }

        // Handle jump input and jump buffering
        /*if (Input.GetKey(KeyCode.Space))
        {
            if (coyoteTimeCounter > 0f)
            {
                Jump();
            }
            else if (jumpBufferCounter > 0f)
            {
                Jump();
            }
        }*/

        jumpBufferCounter -= Time.deltaTime;

        // Set animation parameters
        //anim.SetFloat("speed", Mathf.Abs(horizontal));
        //anim.SetFloat("velocityY", rb.velocity.y);
    }

    // Handle jump logic
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping = true;
        jumpBuffered = false;
        jumpBufferCounter = 0f;
    }
}