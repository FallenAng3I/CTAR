using UnityEngine;

namespace InteractSystem
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator myDoor;
        [SerializeField] private bool isOpen;

        public void Interact()
        {
            if (isOpen)
            {
                myDoor.SetTrigger("Close");
                Debug.Log("Дверь закрывается.");
            }
            else if (!isOpen)
            {
                myDoor.SetTrigger("Open");
                Debug.Log("Дверь открывается.");
            }
            
            isOpen = !isOpen;
        }
    }
}
