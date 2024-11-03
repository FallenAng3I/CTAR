using UnityEngine;
using UnityEngine.AI;

public abstract class Temp : MonoBehaviour
{
    public float speed;
    //public float attackRange;    
    public float detectionRange;
    protected Transform player;
    protected NavMeshAgent agent;
    
    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }
    
    protected void Update()
    {
        if (IsPlayerInRange())
        {
            PerformAttack();
            MoveTowardsPlayer();
        }
    }
    
    protected bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) <= detectionRange;
    }
    
    protected abstract void PerformAttack();
    
    private void MoveTowardsPlayer()
    {
        agent.SetDestination(player.position);
    }
}