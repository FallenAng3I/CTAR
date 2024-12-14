using System.Collections;
using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MenuManager
{
    public class SceneTrigger : MonoBehaviour
    {
        [SerializeField] private string targetScene;        // Название сцены для перехода
        [SerializeField] private float fadeDuration = 1f;   // Длительность затемнения    
        
        [SerializeField] private RawImage fadeImage;
        [SerializeField] private CameraFollow player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                CameraFollow rotator = player.GetComponent<CameraFollow>();
                rotator.GetComponent<CameraFollow>().enabled = false;
                
                StartCoroutine(FadeAndSwitchScene());
            }
        }

        private IEnumerator FadeAndSwitchScene()
        {
            fadeImage.gameObject.SetActive(true);
            yield return StartCoroutine(Fade(1));
            
            SceneManager.LoadScene(targetScene);
        }

        private IEnumerator Fade(float targetAlpha)
        {
            Color currentColor = fadeImage.color;
            float startAlpha = currentColor.a;

            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                float alpha = Mathf.Lerp(startAlpha, targetAlpha, t / fadeDuration);
                fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                yield return null;
            }

            fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);
        }
    }
}