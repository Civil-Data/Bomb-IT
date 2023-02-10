using Palmmedia.ReportGenerator.Core.Common;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public int players;
    public string level;

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

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString() + " " + players.ToString() );
    }

    public void randomMap()
    {
        mapGenerator = new MapGenerator(players);
    }
}
