using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu"); // replace with your scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
