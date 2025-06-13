using UnityEditor.U2D.Sprites;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed = 5.0f;
    private float yDirection = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(speed, yDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider != null)
        {
            // Increase ball speed based on the current speed
            if (speed > 0 && speed < 25.0f)
            {
                speed += 0.5f;
            }
            else if(speed < 0 && speed > -25.0f)
            {
                speed -= 0.5f;
            }
            Debug.Log("Collision detected with: " + collision.collider.name);
            speed = -speed; // reverse the speed to change direction
            // reverse the ball's direction on collision
            Vector2 newDirection = new Vector2(-speed, 0.0f);
            rb.linearVelocity = newDirection;
        }
    }

    float RandomYDirection()
    {
        yDirection = Random.Range(-2.0f, 2.0f);
        return yDirection;
    }
}
