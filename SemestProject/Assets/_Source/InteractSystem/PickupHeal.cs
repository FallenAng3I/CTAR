using PlayerSystem;
using UnityEngine;

namespace InteractSystem
{
    public class PickupHeal : MonoBehaviour
    {
        [SerializeField] private Player player;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                switch (player.health)
                {
                    case 3:
                        return;
                    case 2:
                        player.health++;
                        return;
                    case 1:
                        player.health += 2;
                        return;
                }
                Destroy(gameObject); 
            }
        }
    }
}