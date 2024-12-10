using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        public Dialogue dialogue;
        private DialogueTrigger _dialogueTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                _dialogueTrigger = this;
                DialogueManager.Instance.StartDialogue(dialogue);
                Destroy(gameObject);
            }
        }
    }
}