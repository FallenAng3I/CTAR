using _Source.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace _Source.Enemy
{
    public abstract class AEnemy : EnemyInfo
    {
        protected virtual void Start()
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed;
        }
        protected virtual void Update()
        {
            if (IsPlayerInRange())
            {
                MoveTowardsPlayer();
            }
        }
        protected bool IsPlayerInRange()
        {
            return Vector3.Distance(transform.position, player.position) <= detectionRange;
        }

        protected virtual void PerformAttack()
        {
            if (canAttack)
            {
                Debug.Log("Атакую!");
                playerHealth.currentHealth -= damage;
                StartCoroutine(AttackCooldown());
            }
        }
        private void MoveTowardsPlayer()
        {
            agent.SetDestination(player.position);
        }
        
        private IEnumerator AttackCooldown()
        {
            canAttack = false;
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }
    }
}