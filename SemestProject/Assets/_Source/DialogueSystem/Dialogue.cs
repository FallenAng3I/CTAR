using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        public DialogueSlide[] slides;
    }
}