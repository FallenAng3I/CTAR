using PlayerSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; } // Синглтон

        public GameObject dialogueWindow;   
        public Image characterImage;        
        public TMP_Text characterNameText;  
        public TMP_Text dialogueText;       
        public Button nextButton;           
        
        [SerializeField] public PlayerRotator player;
        private Dialogue _currentDialogue;
        private int _currentSlideIndex;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            nextButton.onClick.AddListener(ShowNextSlide);
            dialogueWindow.SetActive(false);
        }

        public void StartDialogue(Dialogue dialogue)
        {
            _currentDialogue = dialogue;
            _currentSlideIndex = 0;

            PlayerRotator rotator = player.GetComponent<PlayerRotator>();
            rotator.GetComponent<PlayerRotator>().enabled = false;
            
            Time.timeScale = 0f;

            dialogueWindow.SetActive(true);
            ShowSlide();
        }

        private void ShowSlide()
        {
            if (_currentSlideIndex >= _currentDialogue.slides.Length)
            {
                EndDialogue();
                return;
            }

            var slide = _currentDialogue.slides[_currentSlideIndex];
            characterImage.sprite = slide.characterImage;
            characterNameText.text = slide.characterName;
            dialogueText.text = slide.dialogueText;
        }

        private void ShowNextSlide()
        {
            _currentSlideIndex++;
            ShowSlide();
        }

        private void EndDialogue()
        {
            PlayerRotator rotator = player.GetComponent<PlayerRotator>();
            rotator.GetComponent<PlayerRotator>().enabled = true;
            
            Time.timeScale = 1f;
            dialogueWindow.SetActive(false);
            _currentDialogue = null;
        }
    }
}