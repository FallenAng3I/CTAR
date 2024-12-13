using InteractSystem;
using UnityEngine;
using ViewSystem;
using WeaponSystem;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        public int health;              // Здоровье игрока  
        public float speed;             // Скорость игрока  
        public float interactRadius;    // Радиус для взаимодействия с предметами  
        
        public bool isDead;             
        public GameObject weapon;       
        
        public Rifle rifle;
        public DeathScreenView deathScreenView;

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
            Vector3 playerPosition = transform.position;
            float minDistance = Mathf.Infinity;
            IInteractable closestInteractable = null;
            
            Collider[] hitColliders = Physics.OverlapBox
                (playerPosition + transform.forward * interactRadius / 2,
                new Vector3(interactRadius, interactRadius, interactRadius));

            foreach (var hitCollider in hitColliders)
            {
                var interactable = hitCollider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    float distance = Vector3.Distance(playerPosition, hitCollider.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestInteractable = interactable;
                    }
                }
            }
            
            if (closestInteractable != null)
            {
                closestInteractable.Interact();
            }
        }

        public void WeaponView()
        {
            Rifle playerRifle = GetComponent<Rifle>();

            if (playerRifle.GetComponent<Rifle>().enabled)
            {
                weapon.SetActive(true);
            }
        }

        public void TakeDamage(int damage)
        {
            if (isDead) return;
            health -= damage;
            
            if (health <= 0 && !isDead)
            {
                isDead = true;
                Death();
            }            
        }

        public void Heal()
        {
            health = 3;
        }

        private void Death()
        {
            deathScreenView.ShowDeathScreen();
            gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Vector3 size = new Vector3(interactRadius, interactRadius, interactRadius);
            Gizmos.DrawWireCube(transform.position + transform.forward * interactRadius / 2, size);
        }
    }
}
