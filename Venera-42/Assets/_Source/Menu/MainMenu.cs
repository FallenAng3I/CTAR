using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно добавьте эту строку для работы с сценами
using UnityEngine.UI;              // Если вам нужно управлять UI

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Debug_Room");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}