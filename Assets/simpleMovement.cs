using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{
    float speedX, speedY;
    public float movSpeed;
    public float speedLimit = 0.5f;


    private Rigidbody2D rb;

    private bool facingLeft = false; // sprite is facing right

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        // make player face right (original sprite faces left)
        

        // Player movement
        speedX = Input.GetAxis("Horizontal") * movSpeed;
        speedY = Input.GetAxis("Vertical") * movSpeed;

        // Diagonal speed limiter
        if (speedX != 0 && speedY != 0)
        {
            speedX *= speedLimit;
            speedY *= speedLimit;
        }

        // Flip based on movement direction
        if (speedX > 0 && facingLeft)
        {
            Flip();
        }
        else if (speedX < 0 && !facingLeft)
        {
            Flip();
        }

        // Apply movement
        rb.velocity = new Vector2(speedX, speedY);

        if(Input.GetKeyDown("space")){
            Shoot();
        }
    }

    void Flip()
    {
        // switch the way the player is facing
        facingLeft = !facingLeft;

        // also flips the FirePoint for proper shooting logic
        transform.Rotate(0f, 180f, 0f);

    }

    void Shoot(){
        
    }

}
