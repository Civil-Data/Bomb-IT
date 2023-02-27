using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class WaitForSceneLoaded : CustomYieldInstruction
{
    readonly string sceneName;
    readonly float timeout;
    readonly float startTime;
    bool timedOut;

    public bool TimedOut => timedOut;

    public override bool keepWaiting
    {
        get
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            var sceneLoaded = scene.IsValid() && scene.isLoaded;

            if (Time.realtimeSinceStartup - startTime >= timeout)
            {
                timedOut = true;
            }

            return !sceneLoaded && !timedOut;
        }
    }

    public WaitForSceneLoaded(string newSceneName, float newTimeout = 10)
    {
        sceneName = newSceneName;
        timeout = newTimeout;
        startTime = Time.realtimeSinceStartup;
    }

    public static IEnumerator AssertSceneLoaded(string beach6)
    {
        var waitForScene = new WaitForSceneLoaded(beach6);
        yield return waitForScene;
        Assert.IsFalse(waitForScene.TimedOut, "Scene " + beach6 + " was never loaded");
    }
}