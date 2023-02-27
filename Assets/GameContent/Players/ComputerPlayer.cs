using GameLogic;
using UnityEngine;
using Random = System.Random;

public class ComputerPlayer : MonoBehaviour, IPlayer
{
    private enum DIRECTIONS
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }
    private DIRECTIONS walkingDirection;

    private string playerName;
    private Random random;

    Player player = new Player();


    // Start is called before the first frame update
    void Start()
    {
        random = new Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (random.Next(1, 10) < 4)
        {
            ChangeWalkDirection();
        }
    }

    public void PlaceBombRequest(Element[,]? gameBoard)
    {
        if (gameBoard[player.X, player.Y] == Element.GROUND)
        {
            // Place the bomb on the players current position.
            gameBoard[player.X, player.Y] = Element.BOMB;

            // gameBoard = DrawDangerZones(gameBoard, X, Y, bombPower);

            if (random.Next(1, 3) > 2) // Should be 50/50 chance of an Escape act.
            {
                Escape(gameBoard);
            }
            else
            {
                Walk(gameBoard); // Walks randomly
            }
        }
    }

    // If the player continue walking in the same direction he might get stuck.
    // Therefor this function will randomly change the players walking direction for example every 3 seconds.
    private void ChangeWalkDirection()
    {
        //if (true)
        //{
        //MakeMove(Vector2.right, MovementRight);
        //}
    }

    private void Walk(Element[,]? gameBoard)
    {
        // Write logic for which directions the computer should walk.
        // This should act like the the computers walking controls instead of keyboard.
        if (gameBoard[player.X, player.Y - 1] == Element.GROUND) // Can Walk NORTH?
        {
            walkingDirection = DIRECTIONS.EAST;
        }
        else if (gameBoard[player.X + 1, player.Y] == Element.GROUND) // Can Walk EAST?
        {

        }
        else if (gameBoard[player.X, player.Y + 1] == Element.GROUND) // Can Walk SOUTH?
        {

        }
        else if (gameBoard[player.X, player.Y - 1] == Element.GROUND) // Can Walk WEST?
        {

        }
    }

    private void Escape(Element[,]? gameBoard)
    {
        // Find an escape route for the player to avoid its own bomb or enemy bombs.
        if (gameBoard[player.X, player.Y] == Element.DANGERZONE)
        {
            // Walk = Random()
        }

        // If route was found, then Walk(ToEscapePosition)
    }

    // Could possibly be virtual in Player class
    public void UseItem()
    {
        // If item is usable, what type of item is it and how can it be used?
        // If a situation where the item is useful accours, then use it.
    }
}
