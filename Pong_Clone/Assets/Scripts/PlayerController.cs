using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform minPos;
    [SerializeField] Transform maxPos;

    [Header("Player Stats")]

    [SerializeField] float speed = 5f;

    private PlayerInputActions playerInputActions;
    
    private Vector2 movement;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Move.performed += OnMove;

        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Move.performed -= OnMove;

        playerInputActions.Disable();
    }

    void Update()
    {
        // Player movement logic
        rb.linearVelocity = new Vector2(0.0f, movement.y * speed);

        // Clamp player position within defined bounds
        float clampedY = Mathf.Clamp(transform.position.y, minPos.position.y, maxPos.position.y);
        transform.position = new Vector2(transform.position.x, clampedY);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Get context input value
        Vector2 input = context.ReadValue<Vector2>();
        movement = new Vector2(0.0f, input.y);
    }
}
