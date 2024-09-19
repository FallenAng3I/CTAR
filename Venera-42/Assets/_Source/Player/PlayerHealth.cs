using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public Light lightSource;           // Ссылка на компонент Light
    public int lightThreshold = 50;     // Порог здоровья, при котором цвет меняется
    public Color healthyColor = Color.HSVToRGB(255, 251, 144); // Цвет, когда здоровье высокое
    public Color midHealthColor = Color.HSVToRGB(135,133,64); // Цвет, когда здоровье низкое
   
        
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    private void Update()
    {
        if (lightSource != null)
        {
            
            if (currentHealth <= lightThreshold)
            {
                lightSource.color = midHealthColor; // Меняем цвет на красный
            }
            else
            {
                lightSource.color = healthyColor; // Меняем цвет на зеленый
            }
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
}

