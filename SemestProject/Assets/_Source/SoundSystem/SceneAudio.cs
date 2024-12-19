using UnityEngine;

namespace SoundSystem
{
    public class SceneAudio : MonoBehaviour
    {
        public AudioClip soundtrack;

        private void Start()
        {
            AudioManager.Instance.PlayMusic(soundtrack);
        }
    }
}