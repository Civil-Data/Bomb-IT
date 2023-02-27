using GameLogic;
using NUnit.Framework;

public class BombRangeTest
{
    Player playerClass = new Player();

    [Test]
    public void TestInitialBombStrength()
    {
        int start = 0;
        start = playerClass.PlayerBombRange(1, start);
        Assert.AreEqual(2, start);
    }

    [Test]
    public void TestIncreaseOfBombStrength()
    {
        int bomb = 2; //Initial Test of bomb
        Assert.Greater(bomb = playerClass.PlayerBombRange(2, bomb), 1); // Test so range do not go down

        Assert.AreEqual(4, bomb = playerClass.PlayerBombRange(2, bomb)); // Tests if bombrangegoes up
        Assert.AreEqual(5, bomb = playerClass.PlayerBombRange(2, bomb));
        Assert.AreEqual(6, bomb = playerClass.PlayerBombRange(2, bomb));
        Assert.AreEqual(7, bomb = playerClass.PlayerBombRange(2, bomb));
        Assert.AreEqual(8, bomb = playerClass.PlayerBombRange(2, bomb));
        Assert.AreEqual(9, bomb = playerClass.PlayerBombRange(2, bomb));
        Assert.AreEqual(10, bomb = playerClass.PlayerBombRange(2, bomb));
    }
}