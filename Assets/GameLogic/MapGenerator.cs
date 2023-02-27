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
        for (row = 0; row < gameBoard.GetLength(0); row++)
        {
            for (col = 0; col < gameBoard.GetLength(1); col++)
            {
                if (gameBoard[row, col] != Element.START) gameBoard[row, col] = Element.GROUND;
            }
        }
        return;
    }

    public List<Position> CreateValidPositions(int players)
    {
        List<Position> validPositions = new List<Position>();
        if (players == 2)
        {
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    if (row == 6 || (col == 12 && row > 6)) continue;
                    else if ((col == 0 && row < 6)) col++;
                    if (gameBoard[row, col] != Element.START)
                    {
                        Position position = new Position();
                        position.Row = row;
                        position.Col = col;
                        validPositions.Add(position);
                    }
                }
            }
            return validPositions;
        }

        else if (players == 4)
        {
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                if (row == 7) continue;
                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    if ((col < 8 && row == 0) || (col > 6 && row == 14) || (col == 14 && row < 7) || (col == 0 && row > 7)) continue;
                    else if (col == 7) col++;
                    if (gameBoard[row, col] != Element.START)
                    {
                        Position position = new Position();
                        position.Row = row;
                        position.Col = col;
                        validPositions.Add(position);
                    }
                }
            }
            return validPositions;
        }
        else
        {
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                if (row == 10) continue;
                for (int col = 0; col < gameBoard.GetLength(1) - 1; col++)
                {
                    if ((col == 0 && col < gameBoard.GetLength(1) - 2) || (col == 12)) col++;
                    if (gameBoard[row, col] != Element.START)
                    {
                        Position position = new Position();
                        position.Row = row;
                        position.Col = col;
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
        for (int row = 0; row < gameBoard.GetLength(0); row++)
        {
            for (int col = 0; col < gameBoard.GetLength(1); col++)
            {
                if (gameBoard[row, col] != Element.WALL && gameBoard[row, col] != Element.START)
                {
                    if (random.Next(1, 11) <= 5)
                    {
                        gameBoard[row, col] = Element.TREE;
                    }
                    else { gameBoard[row, col] = Element.ROCK; }
                }
            }
        }
    }
}