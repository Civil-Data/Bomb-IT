using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject game;
    private GameWindow gameWindow;

    void Start()
    {
        game = GameObject.Find("Grid");
        gameWindow = game.GetComponent<GameWindow>();
    }

    // Start is called before the first frame update
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Starts the game.
        gameWindow.isPaused = false; // This is makes it able to resume to the game with button click.
        SceneManager.UnloadSceneAsync("PauseMenu");
    }

    public void ExitGame()
    {
        Time.timeScale = 1f; // Starts the game.
        SceneManager.LoadScene("Meny");
    }
}
