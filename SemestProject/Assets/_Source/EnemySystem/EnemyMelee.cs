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
            if (IsPlayerInRange())
            {
                MoveTowardsPlayer();
                if (Vector3.Distance(transform.position, _player.position) <= attackRange)
                {
                    PerformAttack();
                }
            }
        }

        protected override void PerformAttack()
        {
            if (IsPlayerInRange() && Vector3.Distance(transform.position, _player.position) < attackRange)
            {
                if (_canAttack)
                {
                    player.TakeDamage(damage);
                    StartCoroutine(AttackCooldown());
                }
            }
        }
        
        private IEnumerator AttackCooldown()
        {
            _canAttack = false;
            yield return new WaitForSeconds(attackCooldown);
            _canAttack = true;
        }
        
        private void MoveTowardsPlayer()
        {
            agent.SetDestination(_player.position);
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}
