namespace Tests
{
    public class TestMapGenerator
    {
        private Element[,]? validGameBoard;
        private MapGenerator mapGenerator;
        private int players = 0;

        [Test]
        public void Test1()
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
        public void Test2()
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
        public void Test3()
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
}