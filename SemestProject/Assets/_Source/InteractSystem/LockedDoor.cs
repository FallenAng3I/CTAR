using UnityEngine;
using PlayerSystem;

namespace InteractSystem
{
    public class LockedDoor : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator myDoor;
        [SerializeField] private bool isOpen;
        [SerializeField] private int requiredKeys; // Количество ключей для открытия двери

        private Player _player;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        public void Interact()
        {
            if (_player.keys == requiredKeys)
            {
                switch (isOpen)
                {
                    case true:
                        myDoor.SetTrigger("Close");
                        break;
                    case false:
                        myDoor.SetTrigger("Open");
                        break;
                }
                isOpen = !isOpen;
            }
            else
            {
                Debug.Log("WARNING: YOU ARE IN RANGE OF ENEMY ARTILLERY!");
                // Например, зажигаем красный свет над дверью.
            }
        }
    }
}