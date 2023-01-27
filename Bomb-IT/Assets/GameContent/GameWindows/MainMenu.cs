using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private MapGenerator mapgenerator;

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
        if(val == 0)
        {
            mapgenerator = new MapGenerator(2);
        }
        if (val == 1)
        {
            mapgenerator = new MapGenerator(4);
        }
        if (val == 2)
        {
            mapgenerator = new MapGenerator(6);
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
