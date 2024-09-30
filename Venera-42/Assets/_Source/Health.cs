using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    public float maxHealth ; 
    public float currentHealth; 
    

    void Start()
    {
        currentHealth = maxHealth; 
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

