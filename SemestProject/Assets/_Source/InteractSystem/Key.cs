using PlayerSystem;
using UnityEngine;

namespace InteractSystem
{
    public class Key : MonoBehaviour, IInteractable
    {
        private Player _player; // ссылка на игрока

        private void Start()
        {
            _player = FindObjectOfType<Player>();
        }
        
        public void Interact()
        {
            _player.keys++;
            Destroy(gameObject);
        }
    }
}
