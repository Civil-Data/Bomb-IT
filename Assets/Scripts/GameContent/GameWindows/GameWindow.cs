using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWindow : MonoBehaviour
{
    public bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
            SceneManager.UnloadSceneAsync("PauseMenu");
        }
    }
}
