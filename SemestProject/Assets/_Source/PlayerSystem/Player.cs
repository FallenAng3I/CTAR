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
        public Vector3 interactAreaSize = new Vector3(1f, 1f, 1f);

        public int keys = 0;
        public bool isDead;             
        public GameObject weapon;
        public GameObject highlightSprite;
        
        public Rifle rifle;
        public DeathScreenView deathScreenView;
        private Canister _currentCanister;

        private void Update()
        {
            WeaponView();
            ReadSpeed();
            CheckForInteractable();
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
                playerPosition + transform.forward * interactAreaSize.z / 2,
                interactAreaSize / 2
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
        
        private void CheckForInteractable()
        {
            var playerPosition = transform.position;

            var hitColliders = Physics.OverlapBox(
                playerPosition + transform.forward * interactAreaSize.z / 2,
                interactAreaSize / 2
            );

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.layer == LayerMask.NameToLayer("Interactable"))
                {
                    highlightSprite.SetActive(true);
                    return;
                }
            }

            highlightSprite.SetActive(false);
        }


        private void WeaponView()
        {
            if (rifle.enabled)
            {
                weapon.SetActive(true);
            }
            else
            {
                weapon.SetActive(false);
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
            Gizmos.DrawWireCube(
                transform.position + transform.forward * interactAreaSize.z / 2, 
                interactAreaSize
            );
        }
    }
}
