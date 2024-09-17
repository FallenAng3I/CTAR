using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public float attackRange;
    public float speed = 3.0f;
    public float detectionRange = 10.0f;
    protected Transform player;
    protected NavMeshAgent agent;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        MoveToNextWaypoint();
    }

    protected virtual void Update()
    {
        if (IsPlayerInRange())
        {
            PerformAttack();
            MoveTowardsPlayer();
        }
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextWaypoint(); // Перемещаемся к следующей точке
        }
    }
    void MoveToNextWaypoint()
    {
        // Если количество путевых точек равно 0, выходим из метода
        if (waypoints.Length == 0) return;

        // Устанавливаем следующую точку назначения
        agent.SetDestination(waypoints[currentWaypointIndex].position);

        // Переходим к следующей точке
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Циклический переход по путевым точкам
    }

    protected bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) <= detectionRange;
      
    }

    protected abstract void PerformAttack();

    private void MoveTowardsPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Если расстояние до игрока слишком малое, не двигайтесь
        if (distance > attackRange) // attackRange - ваше определенное значение
        {
            Vector3 direction = (player.position - transform.position).normalized;
            // Устанавливаем новую позицию немного вбок от игрока
            Vector3 newPosition = player.position - direction * 1.5f; // Убедитесь, что здесь вы устанавливаете адекватное значение, чтобы избежать толчков

            agent.SetDestination(newPosition);
        }
    }
}