using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private CapsuleCollider2D coll;
    private PlayerInput playerInput;

    public bool isDodge;
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float dodgeForce = 8f;
    private float directionX = 0f;
    
    public float groundCheckRadius = 0f;
    public LayerMask groundMask;
    public Transform groundCheck;
    private bool isTouchingGround;

    private bool flipX = true;
    private bool dodge;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
        
        directionX = playerInput.actions["Move"].ReadValue<float>();
        dodge = playerInput.actions["Dodge"].triggered;
        PlayerDodge();

        PlayerAnimator();
        PlayerMoving();
    }
    void PlayerMoving()
    {
        if (directionX>0)
        {
            if (!flipX) Flip();
        }
        else if (directionX<0)
        {
            if (flipX) Flip();
        }

        if (playerInput.actions["Jump"].triggered && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
    }
    void PlayerDodge()
    {
        if (dodge) animator.SetTrigger("Dodge");
        if (isDodge)
        {
            gameObject.layer = LayerMask.NameToLayer("Enemies") ;
            int dx = flipX ? 1 : -1;
            Vector2 force = new Vector2(dx, 0);
            rb.AddForce(force * dodgeForce, ForceMode2D.Force);
            //  = new Vector2(dx * dodgeForce, rb.velocity.y);
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
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
