using UnityEngine;

public class CoffeeShot : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction = Vector2.right;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
