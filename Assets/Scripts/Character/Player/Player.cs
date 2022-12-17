using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private CapsuleCollider2D coll;

    public float moveSpeed = 5f;
    public float jumpForced = 8f;
    public float dodgeSpeed = 8f;
    private float directionX = 0f;
    private float directionY = 0f;
    
    public float groundCheckRadius = 0f;
    public LayerMask groundMask;
    public Transform groundCheck;
    private bool isTouchingGround;

    private bool isDodge;
    private bool flipX = true;

    // Vector3 respawnPoint;
    // public 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
                if (!flipX) Flip();
                break;
            case -1:
                if (flipX) Flip();
                break;
        }

        if (directionY > 0 && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForced);
        }
    }
    public void PlayerDodge()
    {
        // int direX = (flipX ? -1 : 1);
        // rb.velocity = new Vector2(direX * dodgeSpeed, rb.velocity.y);
    }
    void PlayerAnimator()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("OnAir", rb.velocity.y);
        animator.SetBool("OnGround", isTouchingGround);
    }
    void Flip()
    {
        flipX = !flipX;
        if (flipX)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
