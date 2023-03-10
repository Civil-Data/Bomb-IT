using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MapGenerator mapGenerator;

    [SerializeField]
    private int players = 2;
    //public int Players { get; set; } = 2;
    //public string level;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptionsMenu()
    {
        SceneManager.LoadScene("Options");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayerSelect(int val)
    {
        if (val == 0)
        {
            players = 2;
        }
        else if (val == 1)
        {
            players = 4;
        }
        else if (val == 2)
        {
            players = 6;
        }
    }

    public void OpenScene(string level)
    {
        SceneManager.LoadScene(level + players.ToString());
    }

    public void randomMap()
    {
        mapGenerator = new MapGenerator(players);
    }
}
