using UnityEngine;
using UnityEngine.InputSystem;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        // Read vertical input from keyboard
        vertical = 0f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            vertical = 1f;
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            vertical = -1f;

        // Check if player is on ladder and moving vertically
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }

        // Climbing movement
        if (isClimbing)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * speed);
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = 3f; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered: " + collision.tag);
        if (collision.CompareTag("Ladder"))
            isLadder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited: " + collision.tag);
        if (collision.CompareTag("Ladder"))
            isLadder = false;
    }

}
