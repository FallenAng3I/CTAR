using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : Health
{
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Уменьшаем текущее здоровье на величину урона
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
