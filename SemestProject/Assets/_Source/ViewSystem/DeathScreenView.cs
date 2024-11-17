using UnityEngine;
using UnityEngine.SceneManagement;

namespace ViewSystem
{
    public class DeathScreenView : MonoBehaviour
    {
        [SerializeField] private GameObject deathScreen;

        public void ShowDeathScreen()
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }

        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ExitToMainMenu()
        {
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}