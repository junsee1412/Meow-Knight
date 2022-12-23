using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public float lastAttackTime = 0f;
    [HideInInspector]
    public bool inRanged;

    public float speedAttack = 2.5f;
    public LayerMask playerLayers;
    public Transform hitRange;
    public float hitRangeRadius = 0.5f;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        inRanged = Physics2D.OverlapCircle(hitRange.position, hitRangeRadius, playerLayers);
        if (inRanged && Time.time - lastAttackTime > speedAttack)
        {
            Attack();
        }
    }
    public virtual void Attack()
    {
        lastAttackTime = Time.time;
        animator.SetTrigger("Attack");
    }
}