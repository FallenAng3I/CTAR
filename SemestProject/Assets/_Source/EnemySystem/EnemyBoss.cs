using System.Collections;
using UnityEngine;
using WeaponSystem;

namespace EnemySystem
{
    public class EnemyBoss : AEnemy
    {
        public float attackRange;             // Радиус атаки                       
        public float cooldown;                // Кулдаун между очередями            
        public int shots;                     // Количество выстрелов за очередь    
        public float fireRate;                // Интервал между выстрелами в очереди

        public Transform shootPivot;        
        public GameObject projectilePrefab; 
        public Projectile projectile;       

        private bool _isShooting;

        private void Update()
        {
            if (!IsPlayerInRange()) return;
            
            RotateTowardsPlayer();

            if (!_isShooting)
            {
                StartCoroutine(FireBurst());
            }
        }

        private void RotateTowardsPlayer()
        {
            Vector3 direction = (_player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }

        private IEnumerator FireBurst()
        {
            _isShooting = true;

            for (int i = 0; i < shots; i++)
            {
                if (!IsPlayerInRange()) break;

                ShootProjectile();
                yield return new WaitForSeconds(fireRate);
            }

            yield return new WaitForSeconds(cooldown);
            _isShooting = false;
        }

        private void ShootProjectile()
        {
            GameObject projectiles = Instantiate(projectilePrefab, shootPivot.position, shootPivot.rotation);

            Projectile bulletComponent = projectiles.GetComponent<Projectile>();
            bulletComponent.damage = damage;

            Rigidbody bulletRb = projectiles.GetComponent<Rigidbody>();
            bulletRb.velocity = projectiles.transform.forward * projectile.speed;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}
