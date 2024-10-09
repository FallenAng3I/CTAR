namespace _Source.Enemy
{
    public class EnemyHealth : AHealth
    {
        public void TakeDamage(float damageAmount)
        {
            currentHealth -= damageAmount;
        }
        private void Update()
        {
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
}