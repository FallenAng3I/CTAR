using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно добавьте эту строку для работы с сценами
using UnityEngine.UI;              // Если вам нужно управлять UI

public class MainMenu : MonoBehaviour
{
    void StartGame()
    {
        SceneManager.LoadScene("Debug_Room");
    }
}