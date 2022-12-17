using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private Animator animator;
    private float lastAttackTime = 0f;
    private bool inRanged;

    public float speedAttack = 2.5f;
    public LayerMask playerLayers;
    public Transform hitRange;
    public float hitRangeRadius = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        inRanged = Physics2D.OverlapCircle(hitRange.position, hitRangeRadius, playerLayers);
        if (inRanged && Time.time - lastAttackTime > speedAttack)
        {
            Attack();
        }
    }
    void Attack()
    {
        lastAttackTime = Time.time;
        animator.SetTrigger("Attack");
    }
}