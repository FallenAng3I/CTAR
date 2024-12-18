using System.Collections;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyMelee : AEnemy
    {
        public float attackRange;       // Радиус атаки 
        public float attackCooldown;    // Кулдаун атаки
        
        private bool _canAttack = true;
        
        private void Update()
        {
            if (!IsPlayerInRange()) return;
            
            MoveTowardsPlayer();
            if (Vector3.Distance(transform.position, _player.position) <= attackRange)
            {
                PerformAttack();
            }
        }

        private new bool IsPlayerInRange() // Метод обнаружения игрока
        {
            return Vector3.Distance(transform.position, _player.position) <= detectionRange;
        }

        private void PerformAttack()
        {
            if (IsPlayerInRange() && Vector3.Distance(transform.position, _player.position) < attackRange)
            {
                if (_canAttack)
                {
                    animator.SetTrigger("Punch");
                    player.TakeDamage(damage);
                    agent.isStopped = true;
                    StartCoroutine(AttackCooldown());
                }
            }
        }
        
        private IEnumerator AttackCooldown()
        {
            _canAttack = false;
            yield return new WaitForSeconds(attackCooldown);
            animator.SetTrigger("Punched");
            _canAttack = true;
            agent.isStopped = false;
        }
        
        private void MoveTowardsPlayer()
        {
            animator.SetBool("isAttacking", true);
            agent.SetDestination(_player.position);
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }
    }
}
