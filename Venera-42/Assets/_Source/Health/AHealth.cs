using UnityEngine;

namespace _Source
{
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
            gameObject.SetActive(false);
        }
    }
}