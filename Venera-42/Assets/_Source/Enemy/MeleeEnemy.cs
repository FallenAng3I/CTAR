using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float attackRange = 2.0f;

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
        // Логика атаки ближнего боя
        Debug.Log("МeleeEnemy атакует в ближнем бою!");
    }
}
