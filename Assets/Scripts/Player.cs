using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;

    public float moveSpeed = 5f;
    public float jumpForced = 8f;
    public float dodgeSpeed = 8f;
    float direction = 0f;
    
    public float groundCheckRadius = 0f;
    public LayerMask groundMask;
    public Transform groundCheck;
    bool isTouchingGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
        direction = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        switch (direction)
        {
            case 1:
                sprite.flipX = false;
                break;
            case -1:
                sprite.flipX = true;
                break;
        }
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForced);
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("OnAir", rb.velocity.y);
        animator.SetBool("OnGround", isTouchingGround);
        animator.SetBool("Dodge", false);
    }
}
