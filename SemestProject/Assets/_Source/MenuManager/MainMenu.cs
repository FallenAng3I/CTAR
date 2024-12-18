using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuManager
{
    public class MainMenu : MonoBehaviour
    {
        public void StartTutorial()
        {
            SceneManager.LoadScene("Tutorial_Level");
        }

        public void StartGame()
        {
            SceneManager.LoadScene("Level_1");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}