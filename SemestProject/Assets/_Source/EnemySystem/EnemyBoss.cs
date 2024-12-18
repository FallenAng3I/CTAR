using System.Collections;
using UnityEngine;
using WeaponSystem;

namespace EnemySystem
{
    public class EnemyBoss : AEnemy
    {
        public float attackRange;               // Радиус атаки
        public float fireRate;                  // Скорострельность (выстрелов в секунду)
        public int burstDuration;               // Длительность очереди (в секундах)
        public float reloadTime;                // Время перезарядки (в се  кундах)

        public Transform shootPivot;
        public GameObject projectilePrefab;
        public Projectile projectile;

        private bool _isReloading;
        private bool _isShooting;

        private void Update()
        {
            if (!IsPlayerInRange()) return;

            RotateTowardsPlayer();

            if (!_isShooting && !_isReloading)
            {
                StartCoroutine(AttackCycle());
            }
        }

        private void RotateTowardsPlayer()
        {
            animator.SetBool("isAttacking", true);

            Vector3 direction = (_player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }

        private IEnumerator AttackCycle()
        {
            _isShooting = true;

            float timeElapsed = 0f;
            float interval = 1f / fireRate; // Время между выстрелами

            while (timeElapsed < burstDuration)
            {
                if (!IsPlayerInRange()) break;

                ShootProjectile();
                timeElapsed += interval;
                yield return new WaitForSeconds(interval);
            }

            _isShooting = false;
            _isReloading = true;

            yield return new WaitForSeconds(reloadTime);

            _isReloading = false;
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
