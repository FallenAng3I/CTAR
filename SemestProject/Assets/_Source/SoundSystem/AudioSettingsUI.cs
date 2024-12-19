using UnityEngine;
using UnityEngine.UI;

namespace SoundSystem
{
    public class AudioSettingsUI : MonoBehaviour
    {
        public Slider musicSlider;
        public Slider sfxSlider;
        public Button muteMusicButton;
        public Button muteSFXButton;

        private bool isMusicMuted = false;
        private bool isSFXMuted = false;

        private void Start()
        {
            musicSlider.value = AudioManager.Instance.musicVolume;
            sfxSlider.value = AudioManager.Instance.sfxVolume;

            musicSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXVolume);

            muteMusicButton.onClick.AddListener(ToggleMusicMute);
            muteSFXButton.onClick.AddListener(ToggleSFXMute);
        }

        private void ToggleMusicMute()
        {
            isMusicMuted = !isMusicMuted;
            AudioManager.Instance.SetMusicVolume(isMusicMuted ? 0f : musicSlider.value);
        }

        private void ToggleSFXMute()
        {
            isSFXMuted = !isSFXMuted;
            AudioManager.Instance.SetSFXVolume(isSFXMuted ? 0f : sfxSlider.value);
        }
    }
}