using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerInput playerInput;

    private bool isAttack;
    private int noOfAttack = 0;
    private float lastAttackTime = 0f;
    
    public float maxComboDelay = 1.0f;
    public float speedAttack = 0.5f;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        isAttack = playerInput.actions["Attack"].triggered;
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
