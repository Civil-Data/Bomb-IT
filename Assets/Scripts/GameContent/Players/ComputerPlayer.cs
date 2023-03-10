using Assets.GameLogic;
using GameLogic;
using UnityEngine;
using Random = System.Random;

namespace GameContent
{

    public class ComputerPlayer : MonoBehaviour, IPlayer
    {
        //private enum DIRECTIONS
        //{
        //    NORTH,
        //    EAST,
        //    SOUTH,
        //    WEST
        //}
        //private DIRECTIONS walkingDirection;

        private KeyCode Up = KeyCode.W;
        private KeyCode Down = KeyCode.S;
        private KeyCode Left = KeyCode.A;
        private KeyCode Right = KeyCode.D;
        private KeyCode[] movement = new KeyCode[4];

        private float timer;



        private string playerName;
        private Random random;

        Player player = new Player();

        //CharacterMovement cm;

        public Rigidbody2D playerBody { get; set; }
        private Vector2 move = Vector2.zero;

        //Animation
        [SerializeField]
        public AnimatedRenderer MovementUp;
        [SerializeField]
        public AnimatedRenderer MovementDown;
        [SerializeField]
        public AnimatedRenderer MovementLeft;
        [SerializeField]
        public AnimatedRenderer MovementRight;
        private AnimatedRenderer lastMovement;




        // Start is called before the first frame update
        void Start()
        {
            random = new Random();
            player.Speed = 105;
            movement[0] = Up;
            movement[1] = Down;
            movement[2] = Left;
            movement[3] = Right;
            //Vector2 startPos = transform.position;
        }

        //Gets Component from player
        private void Awake()
        {
            playerBody = GetComponent<Rigidbody2D>();
            lastMovement = MovementDown;
        }

        // Update is called once per frame
        void Update()
        {
            ChangeWalkDirection();


        }

        private void FixedUpdate()
        {
            Vector2 pos = playerBody.position;
            Vector2 translationMovement = move * player.Speed * Time.fixedDeltaTime;
            playerBody.MovePosition(pos + translationMovement);
        }

        public void MakeMove(Vector2 newDirection, AnimatedRenderer directionAnimation)
        {
            move = newDirection;

            // MovementUp.enabled = directionAnimation == MovementUp;
            //  MovementDown.enabled = directionAnimation == MovementDown;
            //  MovementLeft.enabled = directionAnimation == MovementLeft;
            //  MovementRight.enabled = directionAnimation == MovementRight;

            lastMovement = directionAnimation;
            lastMovement.idle = move == Vector2.zero;
        }


        public void Move(KeyCode movement)
        {
            if (movement == Up)
            {
                MakeMove(Vector2.up, MovementUp);
            }
            else if (movement == Down)
            {
                MakeMove(Vector2.down, MovementDown);
            }
            else if (movement == Left)
            {
                MakeMove(Vector2.left, MovementLeft);
            }
            else if (movement == Right)
            {
                MakeMove(Vector2.right, MovementRight);
            }
            else
            {
                MakeMove(Vector2.zero, lastMovement);
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
                    //Walk(gameBoard); // Walks randomly
                }
            }
        }

        // If the player continue walking in the same direction he might get stuck.
        // Therefor this function will randomly change the players walking direction for example every 3 seconds.
        public void ChangeWalkDirection()
        {
            timer += Time.deltaTime;
            Debug.Log($"\nTimer: {timer}");

            // Change direction every second
            if (timer > 1)
            {
                Move(movement[random.Next(0, 4)]);

                timer = 0;
            }
        }

        //private void Walk(Element[,]? gameBoard)
        //{
        //    // Write logic for which directions the computer should walk.
        //    // This should act like the the computers walking controls instead of keyboard.
        //    if (gameBoard[player.X, player.Y - 1] == Element.GROUND) // Can Walk NORTH?
        //    {
        //        walkingDirection = DIRECTIONS.EAST;
        //    }
        //    else if (gameBoard[player.X + 1, player.Y] == Element.GROUND) // Can Walk EAST?
        //    {

        //    }
        //    else if (gameBoard[player.X, player.Y + 1] == Element.GROUND) // Can Walk SOUTH?
        //    {

        //    }
        //    else if (gameBoard[player.X, player.Y - 1] == Element.GROUND) // Can Walk WEST?
        //    {

        //    }
        //}

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

}
