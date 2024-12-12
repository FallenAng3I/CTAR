using EnemySystem;
using PlayerSystem;
using UnityEngine;

namespace WeaponSystem
{
    public class Projectile : MonoBehaviour
    {
        public float speed;
        public float lifetime = 5f;
        public int damage;
        
        
        private void Awake()
        {
            Destroy(gameObject, lifetime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                player.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
    }
}