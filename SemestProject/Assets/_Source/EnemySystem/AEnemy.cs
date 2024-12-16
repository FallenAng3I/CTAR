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
        private bool _isDead;
        
        protected Animator animator;
        protected Transform _player;
        protected NavMeshAgent agent;
        public Player player;
        
        protected virtual void Start()
        {
            _player = FindObjectOfType<Player>().transform;
            agent = GetComponent<NavMeshAgent>();
            agent.speed = speed;
        }
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        
        protected bool IsPlayerInRange() // Метод обнаружения игрока
        {
            return Vector3.Distance(transform.position, _player.position) <= detectionRange;
        }
        
        public void TakeDamage(int damage)
        {
            if (_isDead) return;
            health -= damage;
            if (health <= 0)
            {
                _isDead = true;
                Death();
            }
        }

        protected virtual void Death()
        {
            Destroy(gameObject);
        }
    }
}
