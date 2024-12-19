using PlayerSystem;
using UnityEngine;

namespace SoundSystem
{
    public class FootstepManager : MonoBehaviour
    {
        [System.Serializable]
        public class SurfaceAudio
        {
            public string surfaceName; // Имя поверхности
            public LayerMask surfaceLayer; // Слой поверхности
            public AudioClip[] stepSounds; // Звуки шагов
        }

        public SurfaceAudio[] surfaces; // Массив поверхностей
        public float stepInterval = 0.5f; // Интервал шагов

        private string _currentSurface = "Default"; // Текущая поверхность
        private float _stepTimer; // Таймер шагов
        private PlayerMovement _playerMovement; // Ссылка на скрипт движения

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (IsPlayerMoving())
            {
                _stepTimer += Time.deltaTime;
                if (_stepTimer >= stepInterval)
                {
                    _stepTimer = 0f;
                    PlayStepSound();
                }
            }
            else
            {
                _stepTimer = 0f;
            }
        }

        private void PlayStepSound()
        {
            foreach (var surface in surfaces)
            {
                if (surface.surfaceName == _currentSurface)
                {
                    var clip = surface.stepSounds[Random.Range(0, surface.stepSounds.Length)];
                    AudioManager.Instance.PlaySound(clip);
                    return;
                }
            }

            // Если поверхность не найдена, играем дефолтный звук
            Debug.LogWarning($"Не найден звук для поверхности: {_currentSurface}");
        }

        private bool IsPlayerMoving()
        {
            return _playerMovement != null && _playerMovement.move.sqrMagnitude > 0.01f;
        }

        public void UpdateSurface(string surfaceName)
        {
            _currentSurface = surfaceName;
        }
    }
}
