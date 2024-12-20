using DialogueSystem;
using UnityEngine;

namespace ViewSystem
{
    public class TutorialTrigger : MonoBehaviour
    {
        public GameObject tutorial; 
        private TutorialTrigger _tutorialTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                tutorial.SetActive(true);
            }
        }
    }
}