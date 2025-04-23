using System;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{
    float speedX, speedY;
    [SerializeField] public float movSpeed;
    [SerializeField] public float speedLimit = 0.5f;


    private Rigidbody2D rb;
    private bool facingLeft = false; // sprite is facing right

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // get input
    void Update()
    {
        // movement input
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

        // update FirePoint based on input
        UpdateFirePointDirection();

        if(Input.GetKeyDown("space")){
            Shoot();
        }
    }

    void Flip()
    {
        // switch the way the player is facing
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        // also flips the FirePoint for proper shooting logic
        // transform.Rotate(0f, 180f, 0f);

    }

    void UpdateFirePointDirection(){
        if(firePoint == null) return;

        UnityEngine.Vector2 moveDir = new UnityEngine.Vector2(speedX, speedY);

        if(moveDir.sqrMagnitude > 0.01f){
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Vector3 spawnPosition = firePoint.position + firePoint.right * 0.2f; // offset bullet forward
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Ignore collision with the player 
            Collider2D playerCol = GetComponent<Collider2D>();
            Collider2D bulletCol = bullet.GetComponent<Collider2D>();
            if(playerCol != null && bulletCol != null)
            {
                Physics2D.IgnoreCollision(bulletCol, playerCol);
            }
            
        }
    }

}
