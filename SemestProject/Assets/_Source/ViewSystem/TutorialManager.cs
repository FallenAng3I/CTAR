using System.Collections;
using TMPro;
using UnityEngine;

namespace ViewSystem
{
    public class TutorialManager : MonoBehaviour
    {
        [System.Serializable]
        public class TutorialSlide
        {
            [TextArea] public string description; // Описание
            public string buttonsHint;            // Подсказка по кнопкам
            public float displayTime = 5f;        // Время отображения слайда
        }

        [Header("UI Elements")]
        public TextMeshProUGUI descriptionText; // Поле для описания
        public TextMeshProUGUI buttonsHintText; // Поле для подсказок

        [Header("Settings")]
        public TutorialSlide[] slides;          // Массив слайдов туториала
        public KeyCode nextKey = KeyCode.Space; // Кнопка для перехода на следующий слайд

        private int _currentSlideIndex;
        private bool _isWaitingForInput;

        private void Start()
        {
            if (slides.Length > 0)
            {
                ShowSlide(0);
            }
        }

        private void Update()
        {
            if (_isWaitingForInput && Input.GetKeyDown(nextKey))
            {
                NextSlide();
            }
        }

        private void ShowSlide(int index)
        {
            if (index < 0 || index >= slides.Length)
            {
                EndTutorial();
                return;
            }

            var slide = slides[index];
            descriptionText.text = slide.description;
            buttonsHintText.text = slide.buttonsHint;

            if (slide.displayTime > 0)
            {
                _isWaitingForInput = false;
                StartCoroutine(AutoNextSlide(slide.displayTime));
            }
            else
            {
                _isWaitingForInput = true;
            }
        }

        private IEnumerator AutoNextSlide(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (!_isWaitingForInput) NextSlide();
        }

        private void NextSlide()
        {
            _currentSlideIndex++;
            ShowSlide(_currentSlideIndex);
        }

        private void EndTutorial()
        {
            descriptionText.text = "";
            buttonsHintText.text = "";
            enabled = false; // Отключаем скрипт
            Debug.Log("Tutorial finished.");
        }
    }
}
