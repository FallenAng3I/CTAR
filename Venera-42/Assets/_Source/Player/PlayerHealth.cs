using UnityEngine;

public class PlayerHealth : AHealth
{
    public Light lightSource;
    public int lightThreshold = 50;
    public Color healthyColor = Color.HSVToRGB(255, 251, 144);
    public Color midHealthColor = Color.HSVToRGB(135, 133, 64);

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
                lightSource.color = midHealthColor;
            }
            else
            {
                lightSource.color = healthyColor;
            }
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }
}