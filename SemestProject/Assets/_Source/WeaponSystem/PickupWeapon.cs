using PlayerSystem;
using UnityEngine;

namespace WeaponSystem
{
    public class PickupRifle : MonoBehaviour
    {
        public LayerMask playerLayer; // Слой игрока
        public Player player;
        
        private void OnTriggerEnter(Collider other)
        {
            Rifle playerRifle = player.GetComponent<Rifle>();
            
            if (playerRifle.GetComponent<Rifle>().enabled == false)
            {
                playerRifle.GetComponent<Rifle>().enabled = true;
            }
            
            Destroy(gameObject);
        }
    }
}