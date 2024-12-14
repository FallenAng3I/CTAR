using PlayerSystem;
using UnityEngine;

namespace InteractSystem
{
    public class PickupHeal : MonoBehaviour, IInteractable
    {
        [SerializeField] private Player player;

        public void Interact()
        {
            player.Heal();
            Destroy(gameObject); 
        }
    }
}