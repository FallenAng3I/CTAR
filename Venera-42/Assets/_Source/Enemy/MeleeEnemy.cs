using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public PlayerHealth playerHealth;
    public float attackCooldown ; // Time in seconds between attacks
    private bool canAttack = true; // To check if the enemy can attack
    
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
            playerHealth.currentHealth -= damage;
            
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false; // Disable attacking
        yield return new WaitForSeconds(attackCooldown); // Wait for the cooldown period
        canAttack = true; // Allow attacking again
    }
}
