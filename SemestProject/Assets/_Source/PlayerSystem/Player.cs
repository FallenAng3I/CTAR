using InteractSystem;
using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        public int health;
        public float speed;
        public float interactRadius;
        public GameObject weapon;
        public Rifle rifle;

        private void Update()
        {
            WeaponView();
            ReadSpeed();
        }

        private void ReadSpeed()
        {
            if (rifle.canShoot || rifle.isReloading)
            {
                speed = (float)2.5;
            }
            else
            {
                speed = 5;
            }
        }

        public void Use()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactRadius);

            foreach (var hitCollider in hitColliders)
            {
                var interactable = hitCollider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                    break;
                }
            }
        }

        public void WeaponView()
        {
            Rifle playerRifle = GetComponent<Rifle>();

            if (playerRifle.GetComponent<Rifle>().enabled == true)
            {
                weapon.SetActive(true);
            }
        }

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
            Destroy(gameObject);
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, interactRadius);
        }
    }
}
