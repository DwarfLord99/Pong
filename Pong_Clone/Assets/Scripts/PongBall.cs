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
        rb.linearVelocity = new Vector2(speed, yDirection);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Paddle>())
        {
            // Increase ball speed
            if (Mathf.Abs(speed) < 25.0f)
            {
                speed += speed > 0 ? 0.5f : -0.5f; // Maintain direction while increasing speed
            }

            speed = -speed; // reverse the speed to change direction

            ChangeYDirection(collision);

            // reverse the ball's direction on collision
            //Vector2 newDirection = new Vector2(rb.linearVelocityX, 0.0f);
            //rb.linearVelocity = newDirection;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // Reverse the ball's direction on wall collision
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -rb.linearVelocity.y);
        }
    }

    void ChangeYDirection(Collision2D collision)
    {
        Transform paddle = collision.transform;

        float relativeIntersectY = (transform.position.y - paddle.position.y);
        float normalizedBounce = relativeIntersectY / (paddle.localScale.y / 2.0f);

        // Calculate new Y direction based on hit position
        Vector2 newVelocity = new Vector2(rb.linearVelocity.x, normalizedBounce * speed);
        rb.linearVelocity = newVelocity;
    }

    float RandomStartSpeed()
    {
        // Pick a random speed of either 5.0f or -5.0f
        return Random.Range(0, 2) == 0 ? 5.0f : -5.0f;
    }
}
