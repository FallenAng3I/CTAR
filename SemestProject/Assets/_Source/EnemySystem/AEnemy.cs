using UnityEngine;

namespace EnemySystem
{
    public abstract class AEnemy : MonoBehaviour
    {
        public int health;
        
        

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Death();
            }
        }
        private void Death()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
