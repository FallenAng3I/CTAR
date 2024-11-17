using _Source.PlayerSystem;
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
            PlayerRotator rotator = player.GetComponent<PlayerRotator>();
            rotator.GetComponent<PlayerRotator>().enabled = false;
            
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            pauseGame = true;
        }
        
        public void Resume()
        {
            PlayerRotator rotator = player.GetComponent<PlayerRotator>();
            rotator.GetComponent<PlayerRotator>().enabled = true;
            
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