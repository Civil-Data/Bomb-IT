using GameLogic;
using System;

namespace Assets.GameLogic
{
    internal class ComputerPlayer : Player
    {
        private string playerName;
        private DIRECTIONS walkingDirection;
        private Random random;
        public int X { get; set; }
        public int Y { get; set; }

        private enum DIRECTIONS
        {
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        /*
         * Player methods should probably be stored as states. For example an 
         * Action state (delegates) such as: Walk, Escape, PlaceBomb. To simulate
         * what the player is currently doing.
         * 
         */


        public ComputerPlayer()
        {
            random = new Random();
            // Initialize Computer configuration
        }

        public void PlaceBombRequest(Element[,]? gameBoard)
        {
            if (gameBoard[X, Y] == Element.GROUND)
            {
                // Place the bomb on the players current position.
                gameBoard[X, Y] = Element.BOMB;

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

            //}
        }

        private void Walk(Element[,]? gameBoard)
        {
            // Write logic for which directions the computer should walk.
            // This should act like the the computers walking controls instead of keyboard.
            if (gameBoard[X, Y - 1] == Element.GROUND) // Can Walk NORTH?
            {
                walkingDirection = DIRECTIONS.EAST;
            }
            else if (gameBoard[X + 1, Y] == Element.GROUND) // Can Walk EAST?
            {

            }
            else if (gameBoard[X, Y + 1] == Element.GROUND) // Can Walk SOUTH?
            {

            }
            else if (gameBoard[X, Y - 1] == Element.GROUND) // Can Walk WEST?
            {

            }
        }

        private void Escape(Element[,]? gameBoard)
        {
            // Find an escape route for the player to avoid its own bomb or enemy bombs.
            if (gameBoard[X, Y] == Element.DANGERZONE)
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
}
