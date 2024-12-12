using System.Collections;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyRange : AEnemy
    {
        public float attackRange;       // Радиус атаки
        public float attackCooldown;    // Кулдаун атаки
        public GameObject projectilePrefab; // Префаб для проджектайла
        
        private bool _canAttack = true;
        private float _projectileSpeed = 20f;  // Скорость полета пули

        private void Update()
        {
            if (IsPlayerInRange())
            {
                MoveTowardsPlayer();
                RotateTowardsPlayer();
                if (_canAttack && Vector3.Distance(transform.position, _player.position) <= attackRange)
                {
                    StartCoroutine(Shoot());
                }
            }
        }

        private void MoveTowardsPlayer()
        {
            agent.SetDestination(_player.position);
        }

        private void RotateTowardsPlayer()
        {
            Vector3 direction = (_player.position - transform.position).normalized;
            
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }

        private IEnumerator Shoot()
        {
            _canAttack = false;
            
            GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody projectileRb = projectileInstance.GetComponent<Rigidbody>();
            
            Vector3 direction = (_player.position - transform.position).normalized;
            projectileRb.velocity = direction * _projectileSpeed;
            
            Destroy(projectileInstance, 5f); // Уничтожаем пулю через 5 секунд
            
            yield return new WaitForSeconds(attackCooldown);
            _canAttack = true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
        
        protected override void PerformAttack()
        {
            // Взрывной враг не использует атаку напрямую, только детонацию
        }
    }
}
