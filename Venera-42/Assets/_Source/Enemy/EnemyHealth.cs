using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Уменьшаем текущее здоровье на величину урона
        
    }
}
