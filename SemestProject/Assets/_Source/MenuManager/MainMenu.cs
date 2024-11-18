using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuManager
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Tutorial_Level");
        }

        public void StartLevel1()
        {
            SceneManager.LoadScene("Level_1");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}