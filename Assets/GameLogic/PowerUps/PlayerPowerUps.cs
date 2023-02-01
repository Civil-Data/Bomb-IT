using GameLogic;
using UnityEngine;

public class PlayerPowerUps : PowerUp
{
    public float bombFactor = 2f;

    protected void SpeedPowerIncrease(Collision2D collision2D)
    {
        if (collision2D.rigidbody.tag == "Player")
        {
            GameObject gb = collision2D.gameObject;
            Player player = gb.GetComponent<Player>();

            if (player.speed < 1)
                player.speed = UnityEngine.Random.Range(1.5f, 3f);

            //PowerupExpires()
            Destroy(gb);
        }
    }


    protected void PushableBombPowerUp(Collision2D collision2D)
    {
        if (collision2D.rigidbody.tag == "Player")
        {
            GameObject gb = collision2D.gameObject;
            Player player = gb.GetComponent<Player>();

            if (player.strongBoi != true)
                player.strongBoi = true;

            //PowerupExpires()
            Destroy(gb);
        }
    }

    public void RandomPowerup(Collision2D collision2D)
    {

        if (collision2D.rigidbody.tag == "Player")
        {
            GameObject gb = collision2D.gameObject;
            Player player = gb.GetComponent<Player>();
            BombPowerUps pb = new();

            int random = Random.Range(1, 4);
            switch (random)
            {
                case 1:
                    PushableBombPowerUp(collision2D);
                    break;
                case 2:
                    SpeedPowerIncrease(collision2D);
                    break;

                case 3:
                    pb.BombAdd(collision2D);
                    break;
                case 4:
                    pb.BombPower(collision2D);
                    break;

            }
            Destroy(gb);
        }
    }
}
