using GameLogic;
using UnityEngine;

public class BombPowerUps : PowerUp
{
    public void IncreaseBombRange(Collision2D collision2D)
    {
        if (collision2D.rigidbody.tag == "Player")
        {
            GameObject gb = collision2D.gameObject;
            Player player = gb.GetComponent<Player>();
            player.BombRange++;
        }
    }

    public void AddBomb(Collision2D collision2D)
    {
        if (collision2D.rigidbody.tag == "Player")
        {
            GameObject gb = collision2D.gameObject;
            Player player = gb.GetComponent<Player>();

            player.NBomb++;
            Destroy(gb);
        }
    }
}
