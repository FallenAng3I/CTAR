using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Здесь можно добавить логику для взаимодействия с объектами
        Destroy(gameObject); // Уничтожаем снаряд при столкновении
    }
}
