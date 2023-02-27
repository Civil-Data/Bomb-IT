using NUnit.Framework;


public class PerformanceTests
{

    CharacterMovement characterMovement = new CharacterMovement();

    [Test]
    public void TestPositiveXAxis()
    {
        Assert.Greater(characterMovement.Move(1, 0, 1, 10).x, 0.1f);
    }

    [Test]
    public void TestNegativeXAxis()
    {
        Assert.Less(characterMovement.Move(-1, 0, 1, 10).x, 0.1f);
    }

    [Test]
    public void TestPositiveYAxis()
    {
        Assert.Greater(characterMovement.Move(0, 1, 1, 10).y, 0.1f);
    }

    [Test]
    public void TestNegativeYAxis()
    {
        Assert.Less(characterMovement.Move(0, -1, 1, 10).y, 0.1f);
    }
}

