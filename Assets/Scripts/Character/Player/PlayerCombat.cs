using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;

    private bool isAttack;
    private int noOfAttack = 0;
    private float lastAttackTime = 0f;
    
    public float maxComboDelay = 1.0f;
    public float speedAttack = 0.5f;
    public int damage = 2;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        isAttack = playerInput.actions["Fire2"].triggered;
        if (Time.time - lastAttackTime > maxComboDelay)
        {
            noOfAttack = 0;
        }

        if (isAttack && Time.time - lastAttackTime >= speedAttack)
        {
            Attack();
        }
        animator.SetInteger("AttackState",noOfAttack);
    }
    
    void Attack()
    {   
        lastAttackTime = Time.time;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Fall") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            noOfAttack = (noOfAttack >= 3 ? noOfAttack = 1 : noOfAttack + 1);
        }
        animator.SetTrigger("Attack");
    }
}
