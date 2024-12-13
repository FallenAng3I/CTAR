using System;
using InteractSystem;
using UnityEngine;

namespace NotesSystem
{
    public class NoteObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private Note note;     // Ссылка на ScriptableObject записки.
        private NoteManager _noteManager;

        private void Start()
        {
            _noteManager = FindObjectOfType<NoteManager>();
        }

        public void Interact()
        {
            _noteManager.ShowNote(note);
        }
    }
}