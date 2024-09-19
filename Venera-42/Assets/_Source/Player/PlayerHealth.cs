using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100; // Максимальное здоровье
    public float currentHealth; // Текущее здоровье
    

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем текущее здоровье равным максимальному
    }

    private void Update()
    {
        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Игрок погиб!");
  
    }
}

