using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jump;
    public bool isJumping=false;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed*Move, rb.velocity.y);
       
        /*if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            Debug.Log("jump");
        }*/
    }
    /*private void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("Ground")) 
       {
            isJumping = false;
       }
    }
   
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }*/
}