using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public int damageAmount = 10;
    private bool canAttack = true;
    public float attackCooldown = 1f; 

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>(); 
    }
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
        if (canAttack && playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("МeleeEnemy атакует в ближнем бою!");
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
