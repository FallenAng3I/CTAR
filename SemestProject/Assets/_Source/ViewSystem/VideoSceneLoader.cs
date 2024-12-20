using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoTriggerWithFade : MonoBehaviour
{
    public VideoPlayer videoPlayer;        // Объект с VideoPlayer
    public RawImage fadeImage;            // RawImage для затемнения
    public float fadeDuration = 5f;       // Длительность анимации затемнения
    public GameObject canvas;             // Canvas для отключения UI
    public string sceneToLoad;            // Имя сцены для загрузки
    public AudioSource backgroundMusic;   // Источник фоновой музыки

    private bool isPlaying;

    private void OnTriggerEnter(Collider other)
    {
        if (!isPlaying && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StartCoroutine(PlayVideoWithFade());
        }
    }

    public void PlayVideoFromButton()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayVideoWithFade());
        }
    }

    private IEnumerator PlayVideoWithFade()
    {
        fadeImage.gameObject.SetActive(true); // Включаем RawImage
        yield return StartCoroutine(Fade(1f)); // Затемнение до чёрного
        canvas.gameObject.SetActive(false);   // Выключаем Canvas

        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause(); // Останавливаем фоновую музыку
        }

        PlayVideo();
    }

    private void PlayVideo()
    {
        if (videoPlayer != null)
        {
            isPlaying = true;
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoEnd; // Подписываемся на окончание видео
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        isPlaying = false;
        videoPlayer.loopPointReached -= OnVideoEnd; // Отписываемся от события окончания

        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause(); // Включаем музыку обратно
        }

        SceneManager.LoadScene(sceneToLoad); // Загружаем сцену
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
