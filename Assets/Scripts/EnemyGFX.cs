using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public bool facingLeft = false; // enemy is facing right

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f && facingLeft)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            Flip();
        }
        else if (aiPath.desiredVelocity.x <= -0.01f && !facingLeft)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            Flip();
        }

    }

    void Flip()
    {
        // switch the way the enemy is facing
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
