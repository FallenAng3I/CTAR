using UnityEngine;

namespace NotesSystem
{
    [CreateAssetMenu(fileName = "NewNote", menuName = "Note System/Note")]
    public class Note : ScriptableObject
    {
        public enum NoteType { Paper, Monitor } // Тип записки
        [TextArea(5, 10)]
        public string noteText; // Текст записки
        public NoteType noteType;
    }
}