using Pathfinding;
using UnityEngine;

public class CoffeeBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] private float lifetime = 2f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; // make the bullet move in the direction it's facing
        Destroy(gameObject, lifetime); // bullet disappears after 3 seconds
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // destroy on impact
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // destroy enemy
            Destroy(gameObject); // destroy bullet
            Debug.Log("Customer got shot!");
        }
    }
}
