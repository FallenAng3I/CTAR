using UnityEngine;

namespace InteractSystem
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator myDoor;
        [SerializeField] private bool isOpen;

        public void Interact()
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
    }
}
