using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Component that handles GameObject physics
    private Rigidbody2D rb;

    //Able to be altered in the Unity Editor
    public float speed = 5;
    public float jumpForce = 5;

    private bool isGrounded = true;
    //Used to make the player face the correct direction
    public bool facingRight;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Store reference to this object's Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Handles all the necessary movement for the player
        DoMovement();
    }


    /*
     * Reads player input and then accounts for basic side-to-side movement, jumping, and dashing
     */
    private void DoMovement()
    {
        //Move Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
            if (facingRight)
            {
                facingRight = !facingRight;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        //Move Right
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
            if (!facingRight)
            {
                facingRight = !facingRight;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        //Jump
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            isGrounded = false;
            
        }
    }
}
