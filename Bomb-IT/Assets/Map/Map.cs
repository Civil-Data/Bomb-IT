using UnityEngine;

public class Map : MonoBehaviour
{
    private const int heigth = 16;
    private const int width = 32;
    //public Grid gameGrid;
    public Tile[,] map;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateTiles()
    {
        for (int i = 0; i < heigth; i++)
        {
            for (int j = 0; i < width; j++)
            {
                Tile tile = new Tile();
                map[i, j] = tile;
            }
        }
    }

}
