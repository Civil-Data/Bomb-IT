using GameLogic;
using UnityEngine;

public class BombPowerUps : PowerUp
{
    public const int bombPower = 2;

    public void BombPower(Collision2D collision2D)
    {
        if (collision2D.rigidbody.tag == "Player")
        {
            GameObject gb = collision2D.gameObject;
            Player player = gb.GetComponent<Player>();
            foreach (Bomb b in player.n_Bomb)
            {
                if (b.BombPower != bombPower)
                    b.BombPower = bombPower;
            }
        }
    }

    public void BombAdd(Collision2D collision2D)
    {
        if (collision2D.rigidbody.tag == "Player")
        {
            GameObject gb = collision2D.gameObject;
            Player player = gb.GetComponent<Player>();

            if (player.n_Bomb.Count < 5)
            {
                Bomb bomb = new Bomb();
                player.n_Bomb.Add(bomb);
            }
            Destroy(gb);
        }
    }
}
