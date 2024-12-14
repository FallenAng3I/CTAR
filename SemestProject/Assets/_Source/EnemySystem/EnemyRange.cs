using System.Collections;
using UnityEngine;
using WeaponSystem;

namespace EnemySystem
{
    public class EnemyRange : AEnemy
    {
        public float attackRange;            // Радиус атаки
        public float stopRange;              // Радиус, на котором противник останавливается
        public float attackCooldown;         // Кулдаун атаки

        public Transform shootPivot;
        public GameObject projectilePrefab;
        public Projectile projectile;
        
        private bool _canAttack = true;

        private void Update()
        {
            if (IsPlayerInRange())
            {
                float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

                if (distanceToPlayer > stopRange)
                {
                    MoveTowardsPlayer();
                }
                else
                {
                    agent.isStopped = true;
                    RotateTowardsPlayer();
                    if (_canAttack && distanceToPlayer <= attackRange)
                    {
                        StartCoroutine(ShootProjectile());
                    }
                }
            }
            else
            {
                agent.isStopped = false;
            }
        }

        private void MoveTowardsPlayer()
        {
            agent.isStopped = false;
            agent.SetDestination(_player.position);
        }

        private void RotateTowardsPlayer()
        {
            Vector3 direction = (_player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }

        private IEnumerator ShootProjectile()
        {
            _canAttack = false;

            GameObject projectiles = Instantiate(projectilePrefab, shootPivot.position, shootPivot.rotation);
                    
            Projectile bulletComponent = projectiles.GetComponent<Projectile>();
            bulletComponent.damage = damage;
                    
            Rigidbody bulletRb = projectiles.GetComponent<Rigidbody>();
            bulletRb.velocity = projectiles.transform.forward * projectile.speed;

            yield return new WaitForSeconds(attackCooldown);
            _canAttack = true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, stopRange);
        }
    }
}
