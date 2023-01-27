using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TestingInUnity
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

    private Element[,]? validGameBoard;
    private MapGenerator mapGenerator;
    private int players = 0;

    [Test]
    public void TestMapGen2Player()
    {
        players = 2;
        mapGenerator = new MapGenerator(players);
        mapGenerator.SetupGameBoard(players);
        mapGenerator.CreateValidPositions(players);
        mapGenerator.AddElements(players);

        int count = 0;
        if (players == 2)
        {
            for (int i = 0; i < mapGenerator.gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < mapGenerator.gameBoard.GetLength(1); j++)
                {
                    if ((j == 12 && i > 6) || (i == 6) || (j == 0 && i < 7))
                    {
                        if (mapGenerator.gameBoard[i, j] != Element.WALL) count++;
                    }

                }
            }
            if (count == 25) Assert.Pass();
            else Assert.Fail();
        }
    }
    [Test]
    public void TestMapGen4Player()
    {
        players = 4;
        mapGenerator = new MapGenerator(players);
        mapGenerator.SetupGameBoard(players);
        mapGenerator.CreateValidPositions(players);
        mapGenerator.AddElements(players);
        int count = 0;

        for (int i = 0; i < mapGenerator.gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < mapGenerator.gameBoard.GetLength(1); j++)
            {
                if ((j < 8 && i == 0 || i == 7 || j == 14 && i < 8 || j == 7 || j > 6 && i == 14 || j == 0 && i > 6))
                {
                    if (mapGenerator.gameBoard[i, j] != Element.WALL) count++;
                }
            }
        }
        if (count == 57) Assert.Pass();
        else Assert.Fail();
    }

    [Test]
    public void TestMapGen6Player()
    {
        players = 6;
        mapGenerator = new MapGenerator(players);
        mapGenerator.SetupGameBoard(players);
        mapGenerator.CreateValidPositions(players);
        mapGenerator.AddElements(players);
        int count = 0;

        for (int i = 0; i < mapGenerator.gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < mapGenerator.gameBoard.GetLength(1); j++)
            {
                if ((j == 0 || j == 12 || j == 24 || i == 10))
                {
                    if (mapGenerator.gameBoard[i, j] != Element.WALL) count++;
                }
            }
        }
        if (count == 85) Assert.Pass();
        else Assert.Fail();
    }
}

