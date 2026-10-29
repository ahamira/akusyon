
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private float moveX;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = 0f;

        if (Keyboard.current == null) return;

        if (Keyboard.current.aKey.isPressed)
            moveX = -1f;

        if (Keyboard.current.dKey.isPressed)
            moveX = 1f;

        if (Keyboard.current.spaceKey.wasPressedThisFrame
            && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            moveX * moveSpeed,
            rb.linearVelocity.y
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
