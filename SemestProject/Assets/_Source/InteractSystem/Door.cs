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
            }
            else if (!isOpen)
            {
                myDoor.SetTrigger("Open");
            }
            
            isOpen = !isOpen;
        }
    }
}
