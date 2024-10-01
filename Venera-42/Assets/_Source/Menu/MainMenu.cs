using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Debug_Room");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}