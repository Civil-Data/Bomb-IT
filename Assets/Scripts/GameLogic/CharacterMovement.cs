//using Codice.Client.BaseCommands;
using Assets.GameLogic;
using GameLogic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{

    //Public Variables will be changeble in Unity
    public float speed = 3f;
    [SerializeField]
    public KeyCode Up = KeyCode.W;
    [SerializeField]
    public KeyCode Down = KeyCode.S;
    [SerializeField]
    public KeyCode Right = KeyCode.D;
    [SerializeField]
    public KeyCode Left = KeyCode.A;

    public Rigidbody2D playerBody { get; set; }
    private Vector2 move = Vector2.down;

    public Player player;

    //Animation
    public AnimatedRenderer MovementUp;
    public AnimatedRenderer MovementDown;
    public AnimatedRenderer MovementRight;
    public AnimatedRenderer MovementLeft;
    private AnimatedRenderer lastMovement;

    //Gets Component from player
    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        lastMovement = MovementDown;

        //player = GameObject.Find("Player");
    }

    private void Update()
    {
        //if (Input.GetKey(Up))
        //{
        //    MakeMove(Vector2.up, MovementUp);
        //}
        //else if (Input.GetKey(Down))
        //{
        //    MakeMove(Vector2.down, MovementDown);
        //}
        //else if (Input.GetKey(Left))
        //{
        //    MakeMove(Vector2.left, MovementLeft);
        //}
        //else if (Input.GetKey(Right))
        //{
        //    MakeMove(Vector2.right, MovementRight);
        //}
        //else
        //{
        //    MakeMove(Vector2.zero, lastMovement);
        //}

        Move();
    }

    private void FixedUpdate()
    {
        Vector2 pos = playerBody.position;
        Vector2 translationMovement = move * speed * Time.fixedDeltaTime;
        playerBody.MovePosition(pos + translationMovement);
    }


    public void MakeMove(Vector2 newDirection, AnimatedRenderer directionAnimation)
    {
        move = newDirection;
        //MovementUp.enabled = directionAnimation == MovementUp;
        //MovementDown.enabled = directionAnimation == MovementDown;
        //MovementLeft.enabled = directionAnimation == MovementLeft;
        //MovementRight.enabled = directionAnimation == MovementRight;

        //lastMovement = directionAnimation;
        //lastMovement.idle = move == Vector2.zero;
    }

    public void Move()
    {
        if (Input.GetKey(Up))
        {
            MakeMove(Vector2.up, MovementUp);
        }
        else if (Input.GetKey(Down))
        {
            MakeMove(Vector2.down, MovementDown);
        }
        else if (Input.GetKey(Left))
        {
            MakeMove(Vector2.left, MovementLeft);
        }
        else if (Input.GetKey(Right))
        {
            MakeMove(Vector2.right, MovementRight);
        }
        else
        {
            MakeMove(Vector2.zero, lastMovement);
        }
    }


    public Vector3 Move(float h, float v, float deltaTime, float currentSpeed)
    {
        float x = h * currentSpeed * deltaTime;
        float y = v * currentSpeed * deltaTime;
        return new Vector3(x, y, 0);
    }
}
