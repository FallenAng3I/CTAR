using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount = 20f; // Урон, который наносит пуля
    public float lifespan = 5f; // Время жизни пули

    private void Start()
    {
        // Уничтожить пулю через заданное время
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, попала ли пуля во врага
        if (other.CompareTag("Enemy"))
        {
            // Получаем компонент здоровья врага и наносим урон
            other.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            Destroy(gameObject); // Уничтожаем пулю
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Уничтожаем пулю
        }
        else if (other.CompareTag("Obstacle"))
        {
            // Уничтожаем пулю, если она попадает в препятствие
            Destroy(gameObject);
        }
    }
}
