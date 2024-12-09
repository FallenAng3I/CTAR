using PlayerSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; } // Синглтон

        public GameObject dialogueWindow;  // Родительский объект диалогового окна
        public Image characterImage;
        public TMP_Text characterNameText;
        public TMP_Text dialogueText;
        public Button nextButton;
        
        [SerializeField] public PlayerRotator player;
        private Dialogue currentDialogue;
        private int currentSlideIndex;

        private void Awake()
        {
            // Реализация Singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject); // Удаляем дубликат
                return;
            }

            nextButton.onClick.AddListener(ShowNextSlide);
            dialogueWindow.SetActive(false); // Скрываем окно при старте
        }

        public void StartDialogue(Dialogue dialogue)
        {
            currentDialogue = dialogue;
            currentSlideIndex = 0;

            PlayerRotator rotator = player.GetComponent<PlayerRotator>();
            rotator.GetComponent<PlayerRotator>().enabled = false;
            
            Time.timeScale = 0f;

            dialogueWindow.SetActive(true); // Показываем окно
            ShowSlide();
        }

        private void ShowSlide()
        {
            if (currentSlideIndex >= currentDialogue.slides.Length)
            {
                EndDialogue();
                return;
            }

            var slide = currentDialogue.slides[currentSlideIndex];
            characterImage.sprite = slide.characterImage;
            characterNameText.text = slide.characterName;
            dialogueText.text = slide.dialogueText;
        }

        public void ShowNextSlide()
        {
            currentSlideIndex++;
            ShowSlide();
        }

        public void EndDialogue()
        {
            PlayerRotator rotator = player.GetComponent<PlayerRotator>();
            rotator.GetComponent<PlayerRotator>().enabled = true;
            
            Time.timeScale = 1f; // Возобновление времени
            dialogueWindow.SetActive(false); // Скрываем окно
            currentDialogue = null;
        }
    }
}