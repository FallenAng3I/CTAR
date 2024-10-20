using _Source.Enemy;
using UnityEngine;

namespace _Source.NewWeaponScript
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float damageAmount = 20f;
        [SerializeField] private float lifespan; 
        private void Start()
        {
            Destroy(gameObject, lifespan);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
                Destroy(gameObject);
            }
            else if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                Destroy(gameObject);
                Debug.Log("Bullet destroyed");
            }
        }
    }
}