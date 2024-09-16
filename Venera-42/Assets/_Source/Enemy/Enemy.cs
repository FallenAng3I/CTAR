using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public float detectionRange = 10.0f;
    protected Transform player;
    protected NavMeshAgent agent;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    protected virtual void Update()
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