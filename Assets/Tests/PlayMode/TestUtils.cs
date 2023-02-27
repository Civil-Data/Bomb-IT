using NUnit.Framework;

public class TestUtils
{
    [Test]
    public void TestAssertSceneLoaded()
    {
        WaitForSceneLoaded.AssertSceneLoaded("beach6");
    }
}
