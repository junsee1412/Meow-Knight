using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator animator;

    bool isDodge;
    bool isAttack;
    int noOfAttack = 0;
    float lastAttackTime = 0f;
    public float maxComboDelay = 1.0f;
    public float speedAttack = 0.5f;
    public int damage = 2;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public bool demacia = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isDodge = Input.GetButtonDown("Fire1");
        isAttack = Input.GetButtonDown("Fire2");
        if (Time.time - lastAttackTime > maxComboDelay)
        {
            noOfAttack = 0;
        }

        if (isAttack && Time.time - lastAttackTime >= speedAttack)
        {
            Attack();
        }
        animator.SetBool("Dodge", isDodge);
        animator.SetInteger("AttackState",noOfAttack);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_4") && demacia)
        {
            HitBox(attackPoint.position, attackRange);
        }
    }
    
    void Attack()
    {   
        lastAttackTime = Time.time;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Fall") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            noOfAttack = (noOfAttack >= 3 ? noOfAttack = 1 : noOfAttack + 1);
            HitBox(attackPoint.position, attackRange);
        }
        animator.SetTrigger("Attack");
    }
    void HitBox(Vector2 point, float range)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(point, range, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
