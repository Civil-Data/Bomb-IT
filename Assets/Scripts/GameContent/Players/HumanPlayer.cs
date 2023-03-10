using Assets.GameLogic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Tile1 = UnityEngine.Tilemaps.Tile;

public class HumanPlayer : MonoBehaviour
{
    //Public Variables will be changeble in Unity
    public float speed = 3f;
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;

    public Rigidbody2D playerBody { get; set; }
    private Vector2 move = Vector2.down;
    private float bombCooldown;

    //Animation
    public AnimatedRenderer MovementUp;
    public AnimatedRenderer MovementDown;
    public AnimatedRenderer MovementLeft;
    public AnimatedRenderer MovementRight;
    private AnimatedRenderer lastMovement;

    private Tilemap tMap;

    [SerializeField]
    private GameObject map;

    [SerializeField]
    private Tile1 bomb;

    // Start is called before the first frame update
    void Start()
    {
        tMap = map.GetComponent<Tilemap>();
    }

    //Gets Component from player
    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        lastMovement = MovementDown;

        //player = GameObject.Find("Player");
    }

    private void Update()
    {
        Move();
        PlaceBombRequest();
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

    public void PlaceBombRequest()
    {
        bombCooldown += Time.deltaTime;
        if (bombCooldown > 1 && Input.GetKeyDown(KeyCode.Space))
        {
            RectTransform panel = (tMap.transform.parent.parent.gameObject).GetComponent<RectTransform>();

            int x = (int)panel.rect.width / (int)transform.position.x;
            int y = (int)panel.rect.height / (int)transform.position.y;
            Debug.Log($"\nCoords: x: {x}, y: {y}");

            tMap.SetTile(new Vector3Int(x, y, 0), bomb);
            Debug.Log($"\nParent: {tMap.transform.parent.parent.gameObject.name}");

            bombCooldown = 0;
        }
    }
}
