using System.Collections;
using UnityEngine;

namespace _Source.Enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab; 
        [SerializeField] private Transform spawnPoint; 
        [SerializeField] private float spawnRadius = 5f; 
        [SerializeField] private int numberOfEnemies = 5; 
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
}