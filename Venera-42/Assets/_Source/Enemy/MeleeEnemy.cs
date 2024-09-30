using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class MeleeEnemy : AEnemy
{
    [FormerlySerializedAs("playerHealth")] public AHealth health;
    public float attackCooldown ; 
    private bool canAttack = true; 
    
    public float damage;

    protected override void Update()
    {
        base.Update();
        if (IsPlayerInRange() && Vector3.Distance(transform.position, player.position) < attackRange)
        {
            PerformAttack();
        }
    }

    protected override void PerformAttack()
    {
        if (canAttack)
        {
            Debug.Log("MeleeEnemy атакует в ближнем бою!");
            health.currentHealth -= damage;
            
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false; 
        yield return new WaitForSeconds(attackCooldown); 
        canAttack = true; 
    }
}
