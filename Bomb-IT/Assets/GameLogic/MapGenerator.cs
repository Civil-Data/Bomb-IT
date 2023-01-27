using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

public class MapGenerator
{
    private Random? random;
    public Element[,]? gameBoard;
    private List<Position> validPositions = new List<Position>();

    public MapGenerator(int players)
    {
        random = new Random();
        SetupGameBoard(players);
        validPositions = CreateValidPositions(players);
        AddElements(players);
    }

    public void SetupGameBoard(int players)
    {
        int row = 0, col = 0;
        if (players == 2)
        {
            row = 12; col = 12;
            gameBoard = new Element[row + 1, col + 1];

            gameBoard[0, 0] = Element.START;
            gameBoard[0, 1] = Element.START;
            gameBoard[1, 0] = Element.START;

            gameBoard[row, col] = Element.START;
            gameBoard[row, col - 1] = Element.START;
            gameBoard[row - 1, col] = Element.START;
        }
        else if (players == 4)
        {
            row = 14; col = 14;
            gameBoard = new Element[row + 1, col + 1];

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
        }
        else
        {
            row = 20; col = 24;
            gameBoard = new Element[row + 1, col + 1];

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
        }
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                if (gameBoard[i, j] != Element.START) gameBoard[i, j] = Element.GROUND;
            }
        }
        return;
    }

    public List<Position> CreateValidPositions(int players)
    {
        List<Position> validPositions = new List<Position>();
        if (players == 2)
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (i == 6 || (j == 12 && i > 6)) continue;
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
                    if ((j == 0 && j < gameBoard.GetLength(1) - 2) || (j == 12)) j++;
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

    public void AddElements(int players)
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
