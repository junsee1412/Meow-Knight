using UnityEngine;
public class EnemyCombatMinotaur : EnemyCombat
{
    public int stateOfCrit = 4;
    int numOfAttack = 0;
    
    public override void Attack()
    {
        lastAttackTime = Time.time;
        numOfAttack++;
        if (numOfAttack < stateOfCrit)
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            animator.SetTrigger("AttackCrit");
            numOfAttack = 0;
        }
    }
}
