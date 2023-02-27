using GameLogic;
using NUnit.Framework;


public class LifeTest
{

    Player player = new Player();
    int life = 0;

    [Test]
    public void TestPlayerFullHealth()
    {
        Assert.AreEqual(3, life = player.GetALife(1));
    }

    [Test]
    public void TestPlayerGodMode()
    {
        Assert.AreEqual(10000000, life = player.GetALife(3));
    }

    [Test]
    public void TestIsHit()
    {
        player.Health = 1;
        player.GetALife(0);
        Assert.AreEqual(0, player.Health);
    }

    [Test]
    public void TestAddLife()
    {
        player.Health = 1;
        player.GetALife(2);
        Assert.AreEqual(2, player.Health);
    }

}
