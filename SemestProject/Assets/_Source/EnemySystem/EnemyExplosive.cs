using System.Collections;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyExplosive : AEnemy
    {
        public float explosionRange;       // Радиус взрыва          
        public float timeDetonate;         // Задержка перед взрывом 

        private bool _isExploding;

        private void Update()
        {
            if (IsPlayerInRange())
            {
                MoveTowardsPlayer();
                if (Vector3.Distance(transform.position, _player.position) <= explosionRange && !_isExploding)
                {
                    StartCoroutine(Detonate());
                }
            }
        }

        public IEnumerator Detonate()
        {
            _isExploding = true;
            agent.isStopped = true;

            yield return new WaitForSeconds(timeDetonate);
            
            Collider[] hitObjects = Physics.OverlapSphere(transform.position, explosionRange);
    
            foreach (Collider hitObject in hitObjects)
            {
                hitObject.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            }

            Destroy(gameObject);
        }
        
        private void MoveTowardsPlayer()
        {
            agent.SetDestination(_player.position);
        }
        
        protected override void Death()
        {
            Collider[] hitObjects = Physics.OverlapSphere(transform.position, explosionRange);
    
            foreach (Collider hitObject in hitObjects)
            {
                hitObject.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
            
            Destroy(gameObject);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRange);
        }
        
        protected override void PerformAttack()
        {
            // Взрывной враг не использует атаку напрямую, только детонацию
        }
    }
}