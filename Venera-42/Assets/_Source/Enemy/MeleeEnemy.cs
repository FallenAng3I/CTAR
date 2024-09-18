using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    
    

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
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        // Логика атаки ближнего боя
        Debug.Log("МeleeEnemy атакует в ближнем бою!");
        rb.isKinematic = false;
    }
}
