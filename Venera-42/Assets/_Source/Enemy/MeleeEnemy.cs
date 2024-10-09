using _Source.Enemy;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class MeleeEnemy : AEnemy
{ 
    protected override void Update()
    {
        base.Update();
        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {
            PerformAttack();
        }
    }
    
}