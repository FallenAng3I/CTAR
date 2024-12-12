using PlayerSystem;
using UnityEngine;
using UnityEngine.AI;

namespace EnemySystem
{
    public abstract class AEnemy : MonoBehaviour
    {
        public int health;             // Здоровье врага    
        public int damage;             // Урон врага        
        public float speed;            // Скорость врага    
        public float detectionRange;   // Радиус обнаружения
        protected bool isDead;
        
        protected Transform _player;
        protected NavMeshAgent agent;
        public Player player;
        
        protected virtual void Start()
        {
            _player = FindObjectOfType<Player>().transform;
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed;
        }
        
        protected bool IsPlayerInRange() // Метод обнаружения игрока
        {
            return Vector3.Distance(transform.position, _player.position) <= detectionRange;
        }
        
        protected abstract void PerformAttack();

        public void TakeDamage(int damage)
        {
            if (isDead) return;
            health -= damage;
            if (health <= 0)
            {
                isDead = true;
                Death();
            }
        }

        protected virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}
