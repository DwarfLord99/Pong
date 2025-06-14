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
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Sign(rb.linearVelocity.y) * rb.linearVelocity.magnitude);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DeadZone"))
        {
            // Increase the score once the ball enters the dead zone
            GameManager.instance.ScoreUpdate(1);

            // Destroy the ball
            Destroy(gameObject);

            // Respawn the ball
            RespawnBall();
        }
    }

    void ChangeYDirection(Collision2D collision)
    {
        Transform paddle = collision.transform;

        float relativeIntersectY = (transform.position.y - paddle.position.y);
        float normalizedBounce = relativeIntersectY / (paddle.localScale.y / 2.0f);

        yDirection = normalizedBounce;

        // Calculate new Y direction based on hit position
        Vector2 newVelocity = new Vector2(rb.linearVelocity.x, yDirection * speed);
        rb.linearVelocity = newVelocity;
    }

    float RandomStartSpeed()
    {
        // Pick a random speed of either 5.0f or -5.0f
        return Random.Range(0, 2) == 0 ? 5.0f : -5.0f;
    }

    void RespawnBall()
    {
        GameManager.instance.GameStart();
    }
}
