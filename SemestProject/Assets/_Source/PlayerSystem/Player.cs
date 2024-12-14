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

        public int keys = 0;
        public bool isDead;             
        public GameObject weapon;
        
        public Rifle rifle;
        public DeathScreenView deathScreenView;
        private Canister _currentCanister;

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

        //НИЧЕГО НЕ ТРОГАТЬ В ЭТОМ МЕТОДЕ, ВСЁ РАБОТАЕТ И СЛАВА БОГУ!
        public void Use()
        {
            if (_currentCanister != null)
            {
                _currentCanister.DropCanister();
                _currentCanister = null;
                return;
            }
            
            var playerPosition = transform.position;
            var minDistance = Mathf.Infinity;
            IInteractable closestInteractable = null;

            var hitColliders = Physics.OverlapBox(
                playerPosition + transform.forward * interactRadius / 2,
                new Vector3(interactRadius, interactRadius, interactRadius)
            );

            foreach (var hitCollider in hitColliders)
            {
                var interactable = hitCollider.GetComponent<IInteractable>();
                var distance = Vector3.Distance(playerPosition, hitCollider.transform.position);
                if (interactable == null) continue;
                if (!(distance < minDistance)) continue;
                minDistance = distance;
                closestInteractable = interactable;
            }

            if (closestInteractable == null) return;
            closestInteractable.Interact();
                
            if (closestInteractable is Canister canister)
            {
                _currentCanister = canister;
            }
        }

        private void WeaponView()
        {
            if (rifle.enabled)
            {
                weapon.SetActive(true);
            }
        }

        public void TakeDamage(int damage)
        {
            if (isDead) return;
            health -= damage;

            if (health > 0 || isDead) return;
            isDead = true;
            Death();
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
