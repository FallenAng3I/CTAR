using PlayerSystem;
using UnityEngine;
using WeaponSystem;

namespace InteractSystem
{
    public class PickupWeapon : MonoBehaviour
    {
        public int ammoToAdd = 20;   //Сколько патронов мы будем получать при повторном подборе оружия.
        
        public Player player;
        public GameObject weaponView;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Rifle playerRifle = player.GetComponent<Rifle>();
                
                if (playerRifle.GetComponent<Rifle>().enabled == false)
                {
                    playerRifle.GetComponent<Rifle>().enabled = true;
                    weaponView.gameObject.SetActive(true);
                }
                else if (playerRifle.GetComponent<Rifle>().enabled)
                {
                    if (playerRifle.reserveAmmo + ammoToAdd <= playerRifle.maxReserveAmmo)
                    {
                        playerRifle.reserveAmmo += ammoToAdd;
                    }
                    else
                    {
                        playerRifle.reserveAmmo = playerRifle.maxReserveAmmo;
                    }
                }
                
                Destroy(gameObject);            
            }
        }
    }
}