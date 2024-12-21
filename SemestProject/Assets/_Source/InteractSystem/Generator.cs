using PlayerSystem;
using UnityEngine;
using TMPro;

namespace InteractSystem
{
    public class Generator : MonoBehaviour
    {
        [Header("Quest Settings")]
        [SerializeField] private int requiredCanisters = 5; // Количество канистр для завершения
        private int _collectedCanisters = 0;                // Собранные канистры
        [SerializeField] private Player _player;

        [Header("UI Settings")]
        [SerializeField] private TMP_Text questProgressText; // Текст для отображения прогресса
        [SerializeField] private Color completeColor; // Цвет текста при завершении

        private void Start()
        {
            UpdateQuestUI();
        }

        private void OnTriggerEnter(Collider other)
        {
            var canister = other.GetComponent<Canister>();
            if (canister == null) return;

            Destroy(other.gameObject);
            _collectedCanisters++;
            UpdateQuestUI();

            if (_collectedCanisters >= requiredCanisters)
            {
                OnQuestComplete();
            }
        }

        private void UpdateQuestUI()
        {
            questProgressText.text = $"{_collectedCanisters} / {requiredCanisters}";

            // Если квест выполнен, меняем цвет текста
            if (_collectedCanisters >= requiredCanisters)
            {
                questProgressText.color = completeColor;
            }
        }

        private void OnQuestComplete()
        {
            _player.keys++;
        }
    }
}