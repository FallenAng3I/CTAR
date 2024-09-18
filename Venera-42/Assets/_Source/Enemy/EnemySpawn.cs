using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Transform spawnPoint; // Центр радиуса спавна
    public float spawnRadius = 5f; // Радиус спавна
    public int numberOfEnemies = 5; // Количество врагов

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
           
            Vector3 randomPosition = GetRandomPositionInRadius(spawnPoint.position, spawnRadius);

        
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

           
            float spawnDelay = Random.Range(1f, 2f);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    Vector3 GetRandomPositionInRadius(Vector3 center, float radius)
    {
  
        float randomX = Random.Range(-radius, radius);
        float randomZ = Random.Range(-radius, radius);
        
     
        return new Vector3(center.x + randomX, center.y, center.z + randomZ);
    }
}
