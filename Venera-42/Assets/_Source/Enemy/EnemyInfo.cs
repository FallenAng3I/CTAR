using _Source.Health;
using _Source.Player;
using UnityEngine;
using UnityEngine.AI;

namespace _Source.Enemy
{
    public class EnemyInfo : MonoBehaviour
    {
        [SerializeField] protected PlayerHealth playerHealth;
        [SerializeField] protected float attackRange;
        [SerializeField] protected float speed;
        [SerializeField] protected float detectionRange;
        [SerializeField] protected Transform player;
        [SerializeField] protected NavMeshAgent agent;
        [SerializeField] protected float attackCooldown;
        [SerializeField] protected bool canAttack = true;
        [SerializeField] protected float damage;
        
    }
}
