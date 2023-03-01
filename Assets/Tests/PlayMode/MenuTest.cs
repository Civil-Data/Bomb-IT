using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTest : MonoBehaviour
{
    public MainMenu mainMenu;

    [Test] // Checks that you go to the next scene
    public void PlayGameTest()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Initialize the two scenes
        var expectedSceneIndex = currentSceneIndex + 1;

        mainMenu = new MainMenu();

        mainMenu.PlayGame(); // Initialize the function


        Assert.AreEqual(expectedSceneIndex, SceneManager.GetActiveScene().buildIndex); // Checks that the next scene is loaded
    }

    [Test] //Checks that the option menu scene opens
    public void OpenOptionsTest()
    {
        mainMenu = new MainMenu();

        mainMenu.OpenOptionsMenu(); // Initialize the function

        Assert.AreEqual("Options", SceneManager.GetActiveScene().name); //Checks that option scene is loaded
    }

    [Test] // Checks that you get right amount of player when choosing players
    public void PlayerSelectTest()
    {
        mainMenu = new MainMenu();
        mainMenu.PlayerSelect(2); // Initialize the function with index 2
        Assert.AreEqual(6, mainMenu.players); // Checks that players selected are 6 
    }


}
