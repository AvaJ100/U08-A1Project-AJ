using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Exposed Fields
    [Header("Run Prpoerties")]
    [SerializeField] private float maxRunSpeed = 5.0f;
    [SerializeField] private float groundAcceleration = 4.0f;
    [SerializeField] private float airAcceleration = 2.0f;
    [SerializeField] private float runForceMultiplier = 1.0f;
    [SerializeField] private float frictionFactor = 0.5f;
    [SerializeField] private float jumpPower = 10.0f;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundLayers;

    public int health = 10;
    public GameManager gameManager;

    // component references
    private PlayerInput playerInput;
    private Rigidbody2D rb2d;

    //Private Fields
    private bool _isOnGround;
    private Vector2 _movementInput;

    // Unity Callback Methods
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput.actions["Jump"].started += OnJumpPressed;
        playerInput.actions["Jump"].canceled += OnJumpReleased;
    }

    private void OnDisable()
    {
        playerInput.actions["Jump"].started -= OnJumpPressed;
        playerInput.actions["Jump"].canceled -= OnJumpReleased;
    }

    private void Update()
    {
        _isOnGround = CheckIfOnGround();
        _movementInput = playerInput.actions["Movement"].ReadValue<Vector2>();
    }


    private void FixedUpdate()
    {
        // local variables for running
        float targetSpeed, speedDifference, acceleration, runForce;

        // calculate run force
        targetSpeed = _movementInput.x * maxRunSpeed;
        speedDifference = targetSpeed - rb2d.linearVelocity.x;
        acceleration = _isOnGround ? groundAcceleration : airAcceleration;
        runForce = Mathf.Pow(Mathf.Abs(speedDifference) * acceleration, runForceMultiplier) * Mathf.Sign(speedDifference);

        // fake friction
        if (_isOnGround && Mathf.Approximately(_movementInput.x, 0))
        {
            float amount = Mathf.Min(Mathf.Abs(rb2d.linearVelocity.x), Mathf.Abs(frictionFactor));
            amount *= Mathf.Sign(rb2d.linearVelocity.x);
            rb2d.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }

        // Apply run force to player
        rb2d.AddForce(runForce * Vector2.right);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = _isOnGround ? Color.blue : Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(groundCheckSize.x, groundCheckSize.y, 0.1f));
    }

    //Input Event Callback Methods
    private void OnJumpPressed(InputAction.CallbackContext context)
    {
        if (_isOnGround)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpPower);
        }
    }

    private void OnJumpReleased(InputAction.CallbackContext context)
    {
        if (rb2d.linearVelocity.y > 0)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, rb2d.linearVelocity.y / 2);
        }
    }

    // Class Methods
    private bool CheckIfOnGround()
    {
        return Physics2D.OverlapBox(transform.position, groundCheckSize, 0f, groundLayers);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            GameManager.instance.AddScore(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Ghost"))
        {
            GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
