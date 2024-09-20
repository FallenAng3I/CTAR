using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно добавьте эту строку для работы с сценами

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