using JetBrains.Annotations;
using UnityEngine;

namespace NotesSystem
{
    [CreateAssetMenu(fileName = "NewNote", menuName = "Note System/Note")]
    public class Note : ScriptableObject
    {
        public enum NoteType { Paper, Monitor, Mail } // Добавлен Mail

        [TextArea(5, 10)]
        public string noteText; // Текст записки
        public NoteType noteType;

        // Дополнительные поля для Mail
        [CanBeNull] public string from;    // От кого
        [CanBeNull] public string to;      // Кому
        [CanBeNull] public string subject; // Тема
    }
}