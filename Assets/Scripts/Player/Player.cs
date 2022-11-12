using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;
    CapsuleCollider2D coll;

    public float moveSpeed = 5f;
    public float jumpForced = 8f;
    public float dodgeSpeed = 8f;
    float directionX = 0f;
    float directionY = 0f;
    
    public float groundCheckRadius = 0f;
    public LayerMask groundMask;
    public Transform groundCheck;
    bool isTouchingGround;

    bool isDodge;
    bool flipX;

    // Vector3 respawnPoint;
    // public 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
        isDodge = Input.GetButtonDown("Fire1");

        directionX = Input.GetAxisRaw("Horizontal");
        directionY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
        
        PlayerAnimator();
        PlayerDodge();
        PlayerMoving();
    }
    void PlayerMoving()
    {
        switch (directionX)
        {
            case 1:
                flipX = false;
                break;
            case -1:
                flipX = true;
                break;
        }

        if (directionY > 0 && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForced);
        }
        // else if (directionY < 0 && !isTouchingGround && isAttack)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, -jumpForced);
        //     animator.SetTrigger("Attack");
        // }
    }
    public void PlayerDodge()
    {
        // int direX = (flipX ? -1 : 1);
        // rb.velocity = new Vector2(direX * dodgeSpeed, rb.velocity.y);
    }
    void PlayerAnimator()
    {
        sprite.flipX = flipX;
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("OnAir", rb.velocity.y);
        animator.SetBool("OnGround", isTouchingGround);
    }
}
