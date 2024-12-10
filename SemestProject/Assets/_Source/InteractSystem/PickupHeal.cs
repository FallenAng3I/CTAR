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
                player.Heal();
                Destroy(gameObject); 
            }
        }
    }
}