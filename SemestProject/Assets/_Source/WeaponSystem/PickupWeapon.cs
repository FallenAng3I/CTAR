using PlayerSystem;
using UnityEngine;

namespace WeaponSystem
{
    public class PickupWeapon : MonoBehaviour
    {
        public AWeapon weaponPrefab; // Префаб оружия, который будет подбираться
        public LayerMask playerLayer; // Слой игрока

        private void OnTriggerEnter(Collider other)
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                // Уничтожаем объект оружия на земле
                Destroy(gameObject);
                    
                // Передаем оружие в инвентарь игрока
                player.PickupWeapon(weaponPrefab);
            }
            
            Destroy(gameObject);
        }
    }
}