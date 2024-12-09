using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        public Dialogue dialogue;
        private DialogueTrigger dialogueTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                dialogueTrigger = this; // Запоминаем ссылку на этот триггер
                DialogueManager.Instance.StartDialogue(dialogue);
                Destroy(gameObject);
            }
        }
    }
}