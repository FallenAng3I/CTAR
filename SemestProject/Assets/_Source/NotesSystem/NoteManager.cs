using TMPro;
using UnityEngine;

namespace NotesSystem
{
    public class NoteManager : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private GameObject paperNotePanel;         // Панель для бумажной записки        
        [SerializeField] private GameObject monitorNotePanel;       // Панель для записки на мониторе     
        [SerializeField] private TextMeshProUGUI paperNoteText;     // Текстовое поле бумажной записки    
        [SerializeField] private TextMeshProUGUI monitorNoteText;   // Текстовое поле записки на мониторе 

        private GameObject _activePanel;

        private static NoteManager Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void ShowNote(Note note)
        {
            paperNotePanel.SetActive(false);
            monitorNotePanel.SetActive(false);

            if (note.noteType == Note.NoteType.Monitor)
            {
                monitorNoteText.text = note.noteText;
                monitorNotePanel.SetActive(true);
                _activePanel = monitorNotePanel;
            }
            else //((note.noteType == Note.NoteType.Paper)
            {
                paperNoteText.text = note.noteText;
                paperNotePanel.SetActive(true);
                _activePanel = paperNotePanel;
            }

            Time.timeScale = 0;
        }
        
        public void CloseNote()
        {
            if (_activePanel != null)
            {
                _activePanel.SetActive(false);
                _activePanel = null;
            }

            Time.timeScale = 1;
        }
    }
}