using NUnit.Framework;

public class TestingInUnity
{

    CharacterMovement characterMovement = new CharacterMovement();


    /*
     * Move function which shall be tested: public Vector3 Move(float h, float v, float deltaTime, float currentSpeed)
     * 
     * float h = horizontal input
     * float v = vertical input
     * float deltaTime = completion time in seconds since the last frame. Help keep the game frame independent
     * float currentSpeed = The current speed of the players
     * 
     * 
     * The movement in unity works by X and Y coordinates.
     * To test positive movement on the X-axis. The test simulate that the player have pressed the positive button for character movement on the horizontal axis.
     *      Then the test injects the base movement speed. The input on the X-axis is 1, and on the Y-axis is 0. After the injection the Assert.Greater-command checks if the incrementation of the value on the x-axis was succesful. Ie, value on the x-axis is greater than 0.1
     * 
     * All the movement test works like this except when you test the negative movement. Where you inject negative values and check if the value of the X or Y axis has decreased and is less than 0.1
     */



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
            Assert.AreEqual(count, 25);
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
        Assert.AreEqual(count, 57);
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
        Assert.AreEqual(count, 85);
    }
}

