using GameLogic;
using NUnit.Framework;


public class LifeTest
{

    Player player = new Player();
    int life = 0;

    [Test]
    public void PlayerFullHealth()
    {
        player.GetALife(1);
        Assert.AreEqual(3, life = player.GetALife(1));

    }
    [Test]
    public void PlayerGodMode()
    {
        player.GetALife(3);
        Assert.AreEqual(10000000, life = player.GetALife(3));

    }

}
