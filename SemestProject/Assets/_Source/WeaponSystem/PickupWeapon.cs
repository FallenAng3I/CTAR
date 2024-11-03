using PlayerSystem;
using UnityEngine;

namespace WeaponSystem
{
    public class PickupRifle : MonoBehaviour
    {
        public int ammoToAdd = 20; //Сколько патронов мы будем получать при повторном подборе оружия.
        
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
                    if (playerRifle.reserveAmmo + ammoToAdd <= playerRifle.maxReserveAmmno)
                    {
                        playerRifle.reserveAmmo += ammoToAdd;
                    }
                    else
                    {
                        playerRifle.reserveAmmo = playerRifle.maxReserveAmmno;
                    }
                }
                
                Destroy(gameObject);            
            }
        }
    }
}