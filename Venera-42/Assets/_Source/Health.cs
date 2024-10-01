using UnityEngine;

public abstract class AHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Die()
    {
        Debug.Log("Игрок погиб!");
        gameObject.SetActive(false);
    }
}