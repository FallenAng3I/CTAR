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
            if (!IsPlayerInRange()) return;
            
            MoveTowardsPlayer();
            if (Vector3.Distance(transform.position, _player.position) <= explosionRange && !_isExploding)
            {
                StartCoroutine(Detonate());
            }
        }

        private IEnumerator Detonate()
        {
            _isExploding = true;
            agent.isStopped = true;

            yield return new WaitForSeconds(timeDetonate);
            
            var hitObjects = Physics.OverlapSphere(transform.position, explosionRange);
    
            foreach (var hitObject in hitObjects)
            {
                hitObject.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            }

            Destroy(gameObject);
        }
        
        private void MoveTowardsPlayer()
        {
            animator.SetBool("isAtacking", true);
            agent.SetDestination(_player.position);
        }
        
        protected override void Death()
        {
            var hitObjects = Physics.OverlapSphere(transform.position, explosionRange);
    
            foreach (var hitObject in hitObjects)
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
    }
}