using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public int playerSelect;
    public int level;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            playerSelect = 2;
        }
        else if (val == 1)
        {
            playerSelect = 4;
        }
        else if (val == 2)
        {
            playerSelect = 6;
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString() + " " + playerSelect.ToString() );
    }

    public void randomMap()
    {
        mapGenerator = new MapGenerator(playerSelect);
    }
}
