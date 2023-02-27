using System.Collections;
using UnityEngine.TestTools;

public class SceneLoadTest
{
    [UnityTest]
    public IEnumerator Test4PlayerScenes()
    {
        // Load Scene 1
        WaitForSceneLoaded.AssertSceneLoaded("beach4");

        // Wait for Scene 1 to finish loading
        yield return null;

        // Load Scene 2
        WaitForSceneLoaded.AssertSceneLoaded("winter4");

        // Wait for Scene 2 to finish loading
        yield return null;

        // Check if Scene 3 is loaded
        WaitForSceneLoaded.AssertSceneLoaded("summer4");
        yield return null;

        //Check if Scene 4 is loaded 
        WaitForSceneLoaded.AssertSceneLoaded("sport4");
        yield return null;
    }

    [UnityTest]
    public IEnumerator Test6PlayerScenes()
    {
        // Load Scene 1
        WaitForSceneLoaded.AssertSceneLoaded("beach6");

        // Wait for Scene 1 to finish loading
        yield return null;

        // Load Scene 2
        WaitForSceneLoaded.AssertSceneLoaded("winter6");

        // Wait for Scene 2 to finish loading
        yield return null;

        // Check if Scene 3 is loaded
        WaitForSceneLoaded.AssertSceneLoaded("summer6");
        yield return null;

        //Check if Scene 4 is loaded 
        WaitForSceneLoaded.AssertSceneLoaded("sport6");
        yield return null;
    }
}

