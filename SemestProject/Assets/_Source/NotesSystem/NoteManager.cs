using TMPro;
using UnityEngine;

namespace NotesSystem
{
    public class NoteManager : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private GameObject paperNotePanel;         // Панель для бумажной записки
        [SerializeField] private GameObject monitorNotePanel;       // Панель для записки на мониторе
        [SerializeField] private GameObject mailNotePanel;          // Панель для записки почты
        
        [SerializeField] private TextMeshProUGUI paperNoteText;     // Текстовое поле бумажной записки
        [SerializeField] private TextMeshProUGUI monitorNoteText;   // Текстовое поле записки на мониторе
        
        // Поля для Mail записки
        [Header("Mail Note UI Elements")]
        [SerializeField] private TextMeshProUGUI mailFromText;
        [SerializeField] private TextMeshProUGUI mailToText;
        [SerializeField] private TextMeshProUGUI mailSubjectText;
        [SerializeField] private TextMeshProUGUI mailBodyText;      // Основной текст записки

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
            // Скрыть все панели перед отображением новой
            paperNotePanel.SetActive(false);
            monitorNotePanel.SetActive(false);
            mailNotePanel.SetActive(false);

            switch (note.noteType)
            {
                case Note.NoteType.Paper:
                    paperNoteText.text = note.noteText;
                    paperNotePanel.SetActive(true);
                    _activePanel = paperNotePanel;
                    break;

                case Note.NoteType.Monitor:
                    monitorNoteText.text = note.noteText;
                    monitorNotePanel.SetActive(true);
                    _activePanel = monitorNotePanel;
                    break;

                case Note.NoteType.Mail:
                    mailFromText.text = $"От: {note.from}";
                    mailToText.text = $"Кому: {note.to}";
                    mailSubjectText.text = $"Тема: {note.subject}";
                    mailBodyText.text = note.noteText;
                    mailNotePanel.SetActive(true);
                    _activePanel = mailNotePanel;
                    break;
            }

            Time.timeScale = 0; // Останавливаем время
        }

        public void CloseNote()
        {
            if (_activePanel != null)
            {
                _activePanel.SetActive(false);
                _activePanel = null;
            }

            Time.timeScale = 1; // Возвращаем время
        }
    }
}
