using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 startPoint;
    public int maxHealth = 20;
    int currentHealth;
    public HealthBar healthBar;

    public float damage = 2f;
    public LayerMask playerLayers;
    public Transform attackArea;
    public float attackRadius = 1.0f;
    public float moveSpeed = 2f;
    
    bool isAttack;
    // int noOfAttack = 0;
    // float lastAttackTime = 0f;
    bool inRanged;
    bool flipX = true;
    float dx;
    Animator animator;

    Rigidbody2D rb;
    Collider2D coll;
    GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(maxHealth);
        player = GameObject.FindGameObjectWithTag("Player");
        
        currentHealth = maxHealth;
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

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("IsDead", true);
        this.enabled = false;
        rb.simulated = false;
        coll.enabled = false;
    }
    void Chase()
    {
        dx = GetNewAxis(player.transform.position.x - transform.position.x);
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
