public class HealthBarMinotaur : Health
{
    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= (int)(maxHealth / 3))
        {
            animator.SetBool("HealthLow", true);
        }
        animator.SetTrigger("Hurt");
        
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
