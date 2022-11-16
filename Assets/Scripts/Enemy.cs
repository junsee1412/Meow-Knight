using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 20;
    int currentHealth;

    public float damage = 2f;
    public float moveSpeed = 5f;
    
    bool isAttack;
    // int noOfAttack = 0;
    // float lastAttackTime = 0f;
    public LayerMask playerLayers;
    Animator animator;

    Rigidbody2D rb;
    Collider2D coll;

    public HealthBar healthBar;

    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
}
