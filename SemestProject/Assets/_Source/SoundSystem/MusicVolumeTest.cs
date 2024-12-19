using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

namespace SoundSystem
{
    public class MusicVolumeTest : MonoBehaviour
    {
        public AudioMixer mixer;
        public Slider volumeSlider;

        private void Update()
        {
            mixer.SetFloat("MusicVolume", volumeSlider.value);
        }
    }
}
