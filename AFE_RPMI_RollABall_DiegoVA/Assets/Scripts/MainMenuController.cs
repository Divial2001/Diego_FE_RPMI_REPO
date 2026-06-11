using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

