using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform minPos;
    [SerializeField] Transform maxPos;

    private Rigidbody2D rb;    

    Vector2 currentPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
    }

    void Update()
    {
        GameObject ball = GameObject.FindWithTag("Ball");
        currentPosition = transform.position;
        
        if(ball != null)
        {
            // Get the ball's position
            Vector2 ballPosition = ball.transform.position;
            // Calculate the direction towards the ball
            Vector2 direction = (ballPosition - currentPosition).normalized;
            // Set velocity to move enemy towards ball
            rb.linearVelocity = new Vector2(0.0f, direction.y * speed);

            // Clamp enemy position within defined bounds
            float clampedY = Mathf.Clamp(transform.position.y, minPos.position.y, maxPos.position.y);
            transform.position = new Vector2(transform.position.x, clampedY);
        }
    }
}
