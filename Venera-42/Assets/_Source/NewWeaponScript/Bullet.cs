using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount = 20f; // Урон, который наносит пуля
    public float lifespan = 5f; // Время жизни пули

    private void Start()
    {
     
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Enemy"))
        {
            
            other.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            Destroy(gameObject); 
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject); 
        }
        else if (other.CompareTag("Obstacle"))
        {
           
            Destroy(gameObject);
        }
    }
}
