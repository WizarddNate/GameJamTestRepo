using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded;
    //private bool isFacingRight = true;

    public float speed;
    public float drag;

    public Rigidbody2D body;

    public BoxCollider2D groundCheck;

    public LayerMask groundMask;

    // Update is called once per frame
    void Update() //based off of frame rate. good for inputs.
    {
        //set the input access to horizontal movement, then multiply the direction by speed to move forward
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(xInput) > 0)
        {
            body.velocity = new Vector2(xInput * speed, body.velocity.y);
        }
        
        if (Mathf.Abs(yInput) > 0)
        {
            body.velocity = new Vector2(body.velocity.x, yInput * speed);
        }

       // Flip(); //calls flip method
    }

    void FixedUpdate() //based off of tick update. good for physics simulation.
    {
        CheckGround();

        if (isGrounded)
        {
            body.velocity *= drag;
        }
        
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

    void Flip() //make the player sprite flip depending on where it's facing
    {
        //if (isFacingRight && horizontal < 0f || !!isFacingRight && horizontal > 0f)
        //{
        //    isFacingRight = !isFacingRight;
        //    Vector3 localScale = transform.localScale;
        //    localScale.x *= -1f;
        //    transform.localScale = localScale;
        //}
    }
}
