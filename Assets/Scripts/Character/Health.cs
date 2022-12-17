using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 50;
    private int currentHealth;
    private Rigidbody2D rb;
    private Animator animator;
    private CapsuleCollider2D coll;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider2D>();
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");
        // Debug.Log($"TakeDamage at: {Time.time}");

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        animator.SetBool("IsDead", true);
        // this.enabled = false;
        rb.simulated = false;
        coll.enabled = false;
        if (gameObject.tag == "Player")
        {
            SceneLoader.isGameOver = true;
        }

        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
    }
}
