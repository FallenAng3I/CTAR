using PlayerSystem;
using UnityEngine;
using ViewSystem;

namespace WeaponSystem
{
    public class PickupRifle : MonoBehaviour
    {
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
                else if (playerRifle.GetComponent<Rifle>().enabled == true)
                {
                    playerRifle.reserveAmmo += 20;
                }
                
                Destroy(gameObject);            
            }
        }
    }
}