using System.Collections.Generic;
using Random = System.Random;

public class MapGenerator
{

    private Random? random;
    private enum Element { WALL, TREE, ROCK, GROUND, START }
    private Element[,]? RandomGameBoard1 = new Element[13, 13];
    private Element[,]? RandomGameBoard2 = new Element[15, 15];
    private Element[,]? RandomGameBoard3 = new Element[21, 25];
    private Element[,]? gameBoard;
    private List<Position> validPositions = new List<Position>();

    public MapGenerator(int row, int col, int players)
    {
        random = new Random();
        gameBoard = RandomGameBoard1;
        SetupGameBoard(row, col, players);
        validPositions = CreateValidPositions(players);
        AddElements(players);
    }

    public void SetupGameBoard(int row, int col, int players)
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

    private List<Position> CreateValidPositions(int players)
    {
        List<Position> validPositions = new List<Position>();
        if (players == 2)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (i == 7 || (j == 12 && i > 7)) continue;
                    else if ((j == 0 && i < 6)) j++;
                    if (gameBoard[i, j] != Element.START)
                    {
                        Position position = new Position();
                        position.Row = i;
                        position.Col = j;
                        validPositions.Add(position);
                    }
                }
            }
            return validPositions;
        }

        else if (players == 4)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                if (i == 7) continue;
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if ((j < 8 && i == 0) || (j > 6 && i == 14) || (j == 14 && i < 7) || (j == 0 && i > 7)) continue;
                    else if (j == 7) j++;
                    if (gameBoard[i, j] != Element.START)
                    {
                        Position position = new Position();
                        position.Row = i;
                        position.Col = j;
                        validPositions.Add(position);
                    }
                }
            }
            return validPositions;
        }
        else
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                if (i == 10) continue;
                for (int j = 0; j < gameBoard.GetLength(1) - 1; j++)
                {
                    if ((j == 0 && j < gameBoard.GetLength(1) - 2) || (j == 7)) j++;
                    if (gameBoard[i, j] != Element.START)
                    {
                        Position position = new Position();
                        position.Row = i;
                        position.Col = j;
                        validPositions.Add(position);
                    }
                }
            }
            return validPositions;
        }
    }

    private void AddElements(int players)
    {
        List<Position> validPositions = CreateValidPositions(players);
        foreach (Position position in validPositions)
        {
            if (random.Next(1, 9) <= 3)
            {
                gameBoard[position.Row, position.Col] = Element.WALL;
            }
        }
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                if (gameBoard[i, j] != Element.WALL && gameBoard[i, j] != Element.START)
                {
                    if (random.Next(1, 11) <= 5)
                    {
                        gameBoard[i, j] = Element.TREE;
                    }
                    else { gameBoard[i, j] = Element.ROCK; }
                }
            }
        }
    }
}
