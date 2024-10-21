using UnityEngine;

namespace WeaponSystem
{
    public class Bullet : MonoBehaviour
    {
        public float lifetime = 5f;
        public float damage;
        
        private void Awake()
        {
            Destroy(gameObject, lifetime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Здесь можно добавить логику для обработки столкновения
            // Например, если пуля ударяется в врага, можно вызвать метод у врага, чтобы нанести урон
            // Пример: collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            
            Destroy(gameObject);
        }

        public void Initialize(float bulletDamage)
        {
            damage = bulletDamage;
        }
    }
}