using NUnit.Framework;
using UnityEngine.SceneManagement;

public class MapGeneratorTests
{
    private Element[,]? validGameBoard;
    private MapGenerator mapGenerator;
    private int players = 2;

    public void CreateMapInstace(int players)
    {
        mapGenerator = new MapGenerator(players);
        mapGenerator.SetupGameBoard(players);
        mapGenerator.CreateValidPositions(players);
        mapGenerator.AddElements(players);
    }

    [Test]
    public void Test2PlayerStartPositions()
    {
        CreateMapInstace(players = 2);
        for (int row = 0; row < mapGenerator.gameBoard.GetLength(0); row++)
        {
            for (int col = 0; col < mapGenerator.gameBoard.GetLength(1); col++)
            {
                if ((col == 0 && row == 0)
                    || (row == 0 && col == 1)
                    || (col == 0 && row == 1)
                    || (col == 12 && row == 12)
                    || (col == 12 && row == 11)
                    || (col == 11 && row == 12))
                {
                    if (mapGenerator.gameBoard[row, col] != Element.START) Assert.Fail();
                }
            }
        }
    }

    [Test]
    public void Test4PlayerStartPositions()
    {
        CreateMapInstace(players = 4);
        for (int row = 0; row < mapGenerator.gameBoard.GetLength(0); row++)
        {
            for (int col = 0; col < mapGenerator.gameBoard.GetLength(1); col++)
            {
                if ((col == 0 && row == 0)
                    || (col == 1 && row == 0)
                    || (col == 0 && row == 1)
                    || (col == 14 && row == 14)
                    || (col == 13 && row == 14)
                    || (col == 14 && row == 13)
                    || (col == 14 && row == 0)
                    || (col == 14 && row == 1)
                    || (col == 13 && row == 0)
                    || (col == 0 && row == 14)
                    || (col == 0 && row == 13)
                    || (col == 1 && row == 14))
                {
                    if (mapGenerator.gameBoard[row, col] != Element.START) Assert.Fail();
                }
            }
        }
    }

    [Test]
    public void Test6PlayerStartPositions()
    {
        CreateMapInstace(players = 6);
        for (int row = 0; row < mapGenerator.gameBoard.GetLength(0); row++)
        {
            for (int col = 0; col < mapGenerator.gameBoard.GetLength(1); col++)
            {
                if ((col == 0 && row == 0)
                    || (col == 1 && row == 0)
                    || (col == 0 && row == 1)
                    || (col == 24 && row == 20)
                    || (col == 23 && row == 20)
                    || (col == 24 && row == 19)
                    || (col == 24 && row == 0)
                    || (col == 24 && row == 1)
                    || (col == 23 && row == 0)
                    || (col == 0 && row == 24)
                    || (col == 0 && row == 23)
                    || (col == 1 && row == 24)
                    || (col == 12 && row == 0)
                    || (col == 12 && row == 1)
                    || (col == 12 && row == 2)
                    || (col == 12 && row == 22)
                    || (col == 12 && row == 23)
                    || (col == 12 && row == 24))
                {
                    if (mapGenerator.gameBoard[row, col] != Element.START) Assert.Fail();
                }
            }
        }
    }

    [Test]
    public void TestMapGen2Player()
    {
        CreateMapInstace(players = 2);

        int count = 0;
        if (players == 2)
        {
            for (int row = 0; row < mapGenerator.gameBoard.GetLength(0); row++)
            {
                for (int col = 0; col < mapGenerator.gameBoard.GetLength(1); col++)
                {
                    if ((col == 12 && row > 6) || (row == 6) || (col == 0 && row < 7))
                    {
                        if (mapGenerator.gameBoard[row, col] != Element.WALL) count++;
                    }

                }
            }
            Assert.AreEqual(count, 25);
        }
    }
    [Test]
    public void TestMapGen4Player()
    {
        CreateMapInstace(players = 4);
        int count = 0;

        for (int row = 0; row < mapGenerator.gameBoard.GetLength(0); row++)
        {
            for (int col = 0; col < mapGenerator.gameBoard.GetLength(1); col++)
            {
                if ((col < 8 && row == 0 || row == 7 || col == 14 && row < 8 || col == 7 || col > 6 && row == 14 || col == 0 && row > 6))
                {
                    if (mapGenerator.gameBoard[row, col] != Element.WALL) count++;
                }
            }
        }
        Assert.AreEqual(count, 57);
    }

    [Test]
    public void TestMapGen6Player()
    {
        CreateMapInstace(players = 6);
        int count = 0;

        for (int row = 0; row < mapGenerator.gameBoard.GetLength(0); row++)
        {
            for (int col = 0; col < mapGenerator.gameBoard.GetLength(1); col++)
            {
                if ((col == 0 || col == 12 || col == 24 || row == 10))
                {
                    if (mapGenerator.gameBoard[row, col] != Element.WALL) count++;
                }
            }
        }
        Assert.AreEqual(count, 85);
    }
}

