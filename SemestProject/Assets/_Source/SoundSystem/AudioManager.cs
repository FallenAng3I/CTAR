using UnityEngine;

namespace SoundSystem
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [Header("Audio Sources")]
        public AudioSource musicSource;
        public AudioSource sfxSource;

        [Header("Settings")]
        [Range(0f, 1f)] public float musicVolume = 1f;
        [Range(0f, 1f)] public float sfxVolume = 1f;

        private const string MusicVolumeKey = "MusicVolume";
        private const string SFXVolumeKey = "SFXVolume";

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            LoadSettings();
        }

        public void PlaySound(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip, sfxVolume);
        }

        public void PlayMusic(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }

        public void SetMusicVolume(float volume)
        {
            musicVolume = volume;
            musicSource.volume = musicVolume;
            PlayerPrefs.SetFloat(MusicVolumeKey, musicVolume);
        }

        public void SetSFXVolume(float volume)
        {
            sfxVolume = volume;
            PlayerPrefs.SetFloat(SFXVolumeKey, sfxVolume);
        }

        private void LoadSettings()
        {
            musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
            sfxVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 1f);
        }
    }
}