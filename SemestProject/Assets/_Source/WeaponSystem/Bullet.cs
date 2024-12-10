using EnemySystem;
using UnityEngine;

namespace WeaponSystem
{
    public class Bullet : MonoBehaviour
    {
        public float speed;
        public float lifetime = 5f;
        public int damage;
        
        
        private void Awake()
        {
            transform.Rotate(0, 90, 0);
            Destroy(gameObject, lifetime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out AEnemy enemy))
            {
                enemy.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
    }
}