using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMeny : MonoBehaviour
{
    private Mapgenerator mapgenerator;

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
            mapgenerator = new Mapgenerator(2);
        }
        if (val == 1)
        {
            mapgenerator = new Mapgenerator(4);
        }
        if (val == 2)
        {
            mapgenerator = new Mapgenerator(6);
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("level " + level.ToString());
    }
}
