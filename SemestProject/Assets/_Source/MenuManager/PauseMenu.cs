using PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuManager
{
    public class PauseMenu : MonoBehaviour
    {
        public bool pauseGame;
        public GameObject pauseMenu;
        public PlayerRotator player;
        
        public void Pause()
        {
            player.enabled = false;
            
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            pauseGame = true;
        }
        
        public void Resume()
        {
            player.enabled = true;
            
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            pauseGame = false;
        }
        
        public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}