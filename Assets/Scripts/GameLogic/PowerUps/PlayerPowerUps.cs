using GameLogic;
using UnityEngine;

public class PlayerPowerUps : PowerUp
{
    public float bombFactor = 2f;

    protected void IncreasePlayerSpeed(Collision2D collision2D)
    {
        if (collision2D.rigidbody.tag == "Player")
        {
            GameObject gb = collision2D.gameObject;
            Player player = gb.GetComponent<Player>();

            if (player.Speed < 1)
                player.Speed = UnityEngine.Random.Range(1.5f, 3f);

            //PowerupExpires()
            Destroy(gb);
        }
    }


    protected void GetPushBomb_PowerUp(Collision2D collision2D)
    {
        if (collision2D.rigidbody.tag == "Player")
        {
            GameObject gb = collision2D.gameObject;
            Player player = gb.GetComponent<Player>();

            if (player.StrongBoi != true)
                player.StrongBoi = true;

            //PowerupExpires()
            Destroy(gb);
        }
    }

    public void GetRandomPowerup(Collision2D collision2D)
    {

        if (collision2D.rigidbody.tag == "Player")
        {
            GameObject gb = collision2D.gameObject;
            Player player = gb.GetComponent<Player>();
            BombPowerUps bombPowerUp = new();

            int random = Random.Range(1, 4);
            switch (random)
            {
                case 1:
                    GetPushBomb_PowerUp(collision2D);
                    break;
                case 2:
                    IncreasePlayerSpeed(collision2D);
                    break;

                case 3:
                    bombPowerUp.AddBomb(collision2D);
                    break;
                case 4:
                    bombPowerUp.IncreaseBombRange(collision2D);
                    break;

            }
            Destroy(gb);
        }
    }
}
