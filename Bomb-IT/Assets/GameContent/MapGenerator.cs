using UnityEngine;
using Random = System.Random;

public class MapGenerator
{
    private Random? random;
    private int stage = 0;
    public enum Element { WALL, TREE, ROCK, GROUND, START }
    [SerializeField]
    public GameObject map;
    public Element[,]? RandomGameBoard1 = new Element[15, 20];
    public Element[,]? RandomGameBoard2 = new Element[15, 20];
    public Element[,]? RandomGameBoard3 = new Element[15, 20];
    public Element[,]? FixedGameBoard1 = new Element[15, 20];
    public Element[,]? FixedGameBoard2 = new Element[15, 20];
    public Element[,]? FixedGameBoard3 = new Element[15, 20];
    public Element[,]? gameBoard;

    public MapGenerator(int row, int col, int players)
    {
        random = new Random();
        gameBoard = RandomGameBoard1;
        Position validPositions = new Position();
        SetupGameBoard(row, col, players);
    }



    public void ObstaclesGenerator()
    {
        // Player chooses size for example option 1 which is gameboard1 this option is allocated to gameBoard
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                if (stage == 0)
                {
                    gameBoard[i, j] = Element.GROUND;
                    if (i == 10 && j == 10) { stage = 1; }
                }
                else if (stage == 1
                    && (i == 0 && j == 0)
                    || (i == 0 && j == 5)
                    || (i == 0 && j == 10)
                    || (i == 10 && j == 0)
                    || (i == 10 && j == 5)
                    || (i == 10 && j == 10))
                {
                    gameBoard[i, j] = Element.START;
                    gameBoard[i, j + 1] = Element.START;
                }
                else if (random.Next(1, 5) == 3 && stage == 2)
                {
                    gameBoard[i, j] = Element.WALL;
                }
            }
        }

    }

    private void SetupGameBoard(int row, int col, int players)
    {
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                gameBoard[i, j] = Element.GROUND;
            }
        }

        if (players == 2)
        {
            gameBoard[0, 0] = Element.START;
            gameBoard[0, 1] = Element.START;
            gameBoard[1, 0] = Element.START;

            gameBoard[row, col] = Element.START;
            gameBoard[row, col - 1] = Element.START;
            gameBoard[row - 1, col] = Element.START;
            return;
        }
        else if (players == 4)
        {
            gameBoard[0, 0] = Element.START;
            gameBoard[0, 1] = Element.START;
            gameBoard[1, 0] = Element.START;

            gameBoard[row, col] = Element.START;
            gameBoard[row, col - 1] = Element.START;
            gameBoard[row - 1, col] = Element.START;

            gameBoard[0, col] = Element.START;
            gameBoard[1, col] = Element.START;
            gameBoard[0, col - 1] = Element.START;

            gameBoard[row, 0] = Element.START;
            gameBoard[row, 1] = Element.START;
            gameBoard[row - 1, 0] = Element.START;
            return;
        }
        else
        {
            gameBoard[0, 0] = Element.START;
            gameBoard[0, 1] = Element.START;
            gameBoard[1, 0] = Element.START;

            gameBoard[0, col / 2] = Element.START;
            gameBoard[1, col / 2] = Element.START;
            gameBoard[2, col / 2] = Element.START;

            gameBoard[0, col] = Element.START;
            gameBoard[1, col] = Element.START;
            gameBoard[0, col - 1] = Element.START;

            gameBoard[row, 0] = Element.START;
            gameBoard[row, 1] = Element.START;
            gameBoard[row - 1, 0] = Element.START;

            gameBoard[row, col / 2] = Element.START;
            gameBoard[row - 1, col / 2] = Element.START;
            gameBoard[row - 2, col / 2] = Element.START;

            gameBoard[row, col] = Element.START;
            gameBoard[row, col - 1] = Element.START;
            gameBoard[row - 1, col] = Element.START;
            return;
        }

    }

    //private List<Position> CreateValidPositions(int players)
    //{
    //    List<Position> validPositions = new List<Position>();
    //    if (players == 2)
    //    {
    //        for (int i = 0; i < gameBoard.GetLength(0); i++)
    //        {
    //            for (int j = 0; j < gameBoard.GetLength(1); j++)
    //            {
    //                if (i < 6 && j < 12) j++;
    //                else if (j == 12) break;
    //                if (gameBoard[i, j] != Element.START)
    //                {
    //                    Position position = new Position();
    //                    position.Row = i;
    //                    position.Col = j;
    //                    validPositions.Add(position);
    //                }
    //            }
    //        }


    //    else if (players == 4)
    //        {
    //            gameBoard[0, 0] = Element.START;
    //            gameBoard[0, 1] = Element.START;
    //            gameBoard[1, 0] = Element.START;

    //            gameBoard[row, col] = Element.START;
    //            gameBoard[row, col - 1] = Element.START;
    //            gameBoard[row - 1, col] = Element.START;

    //            gameBoard[0, col] = Element.START;
    //            gameBoard[1, col] = Element.START;
    //            gameBoard[0, col - 1] = Element.START;

    //            gameBoard[row, 0] = Element.START;
    //            gameBoard[row, 1] = Element.START;
    //            gameBoard[row - 1, 0] = Element.START;
    //            return;
    //        }
    //        else
    //        {
    //            gameBoard[0, 0] = Element.START;
    //            gameBoard[0, 1] = Element.START;
    //            gameBoard[1, 0] = Element.START;

    //            gameBoard[0, col / 2] = Element.START;
    //            gameBoard[1, col / 2] = Element.START;
    //            gameBoard[2, col / 2] = Element.START;

    //            gameBoard[0, col] = Element.START;
    //            gameBoard[1, col] = Element.START;
    //            gameBoard[0, col - 1] = Element.START;

    //            gameBoard[row, 0] = Element.START;
    //            gameBoard[row, 1] = Element.START;
    //            gameBoard[row - 1, 0] = Element.START;

    //            gameBoard[row, col / 2] = Element.START;
    //            gameBoard[row - 1, col / 2] = Element.START;
    //            gameBoard[row - 2, col / 2] = Element.START;

    //            gameBoard[row, col] = Element.START;
    //            gameBoard[row, col - 1] = Element.START;
    //            gameBoard[row - 1, col] = Element.START;
    //            return;
    //            return new List<Position>();
    //        }

    //        private void addElements(int players)
    //        {
    //            List<Position> validPositions = CreateValidPositions(players);
    //            foreach (Position position in validPositions)
    //            {
    //                if (random.Next(1, 2) == 2)
    //                {
    //                    gameBoard[position.Row, position.Col] = Element.WALL;
    //                }
    //            }
    //        }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
