using UnityEngine;

namespace DialogueSystem
{
    [System.Serializable]
    public class DialogueSlide
    {
        public string characterName;       // Имя персонажа
        public Sprite characterImage;      // Изображение персонажа
        [TextArea(3, 10)]
        public string dialogueText;        // Текст реплики
    }

    [CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        public DialogueSlide[] slides;     // Массив слайдов
    }
}