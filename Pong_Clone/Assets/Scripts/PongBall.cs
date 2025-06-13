using UnityEngine;

public class PongBall : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed;
    private float yDirection = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = RandomStartSpeed();
    }

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
            Vector2 newDirection = new Vector2(-speed, RandomYDirection());
            rb.linearVelocity = newDirection;
        }
    }

    float RandomYDirection()
    {
        yDirection = Random.Range(-2.0f, 2.0f);
        return yDirection;
    }

    float RandomStartSpeed()
    {
        // Pick a random speed of either 5.0f or -5.0f
        return Random.Range(0, 2) == 0 ? 5.0f : -5.0f;
    }
}
