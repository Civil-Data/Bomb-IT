using UnityEngine;

public class Tile : Map
{
    [SerializeField] private Color baseColor, wallColor;
    [SerializeField] private SpriteRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //type == true = walkingtile
    //type == false = object tile
    public void InitalizeTile(bool type)
    {
        if (type == false)
            _renderer.color = baseColor;
        else _renderer.color = wallColor;
    }
}
