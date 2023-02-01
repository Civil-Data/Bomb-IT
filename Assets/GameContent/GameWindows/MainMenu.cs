using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private MapGenerator mapGenerator;

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
            mapGenerator = new MapGenerator(2);
        }
        if (val == 1)
        {
            mapGenerator = new MapGenerator(4);
        }
        if (val == 2)
        {
            mapGenerator = new MapGenerator(6);
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
