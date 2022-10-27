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
    
    bool isActack;
    int noOfActack = 0;
    // int stateActack = 0;
    float lastActackTime = 0f;
    public float maxComboDelay = 0.9f;

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
        isActack = Input.GetButtonDown("Fire2");
        if (Time.time - lastActackTime > maxComboDelay)
        {
            noOfActack = 0;
        }

        directionX = Input.GetAxisRaw("Horizontal");
        directionY = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

        if (isActack)
        {
            PlayerActack();
        }
        
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
        else if (directionY < 0 && !isTouchingGround && isActack)
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForced);
            animator.SetTrigger("Actack");
        }
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
        animator.SetBool("Dodge", isDodge);
        animator.SetInteger("ActackState", noOfActack);

    }
    void PlayerActack()
    {   
        lastActackTime = Time.time;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Fall") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            noOfActack = (noOfActack >= 3 ? noOfActack = 1 : noOfActack + 1);
        }
        animator.SetTrigger("Actack");
    }
}
