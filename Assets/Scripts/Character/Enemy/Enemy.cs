using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 startPoint;

    public LayerMask playerLayers;
    public Transform attackArea;
    public float attackRadius = 1.0f;
    public float offsetAttack = 0.3f;
    public float moveSpeed = 2f;
    
    private bool inRanged;
    private bool flipX = true;
    private float dx;

    private Animator animator;
    private Rigidbody2D rb;
    private Collider2D coll;
    private GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        startPoint = rb.transform.position;
    }

    void Update()
    {
        inRanged = Physics2D.OverlapCircle(attackArea.position, attackRadius, playerLayers);
        if (inRanged) 
        {
            Chase();
        }
        else
        {
            ReturnStartPoint();
        }
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
    void Chase()
    {
        float offset = (flipX ? -offsetAttack : offsetAttack);
        dx = GetNewAxis(player.transform.position.x - transform.position.x + offset);
        Moving(dx);
    }

    void ReturnStartPoint()
    {
        dx =  GetNewAxis(startPoint.x - transform.position.x);
        Moving(dx);
    }

    void Moving(float axis)
    {
        switch (axis)
        {
            case 1:
                if (!flipX) Flip();
                break;
            case -1:
                if (flipX) Flip();
                break;
        }
        rb.velocity = new Vector2(axis * moveSpeed, rb.velocity.y);
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
    float GetNewAxis(float rawaxis)
    {
        float axis = 0.0f;
        if (rawaxis > 0.05)
        {
            axis = rawaxis/rawaxis;
        }
        else if (rawaxis < -0.05) 
        {
            axis = -rawaxis/rawaxis;
        }
        return axis;
    }
}
