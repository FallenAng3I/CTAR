using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;             

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