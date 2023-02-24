using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameLogic
{

    public class Player : MonoBehaviour
    {
        public List<Bomb> n_Bomb { get; set; }
        public int Id { get; set; } // Do we need this?
        public int bombStrengt { get; set; }
        public int health { get; set; }

        public float speed { get; set; }

        public bool isAlive { get; set; }
        public bool godMode { get; set; }
        public bool strongBoi { get; set; } = false;


        // Start is called before the first frame update
        void Start()
        {
            health = GetALife(1);
            bombStrengt = PlayerBombRange(1);
        }

        // Update is called once per frame
        void Update()
        {
            //bombStrengt = PlayerBombRange(0); // check range

            if (health == 0) //isDead
            {
                isAlive = KillPlayer();
            }

            if (godMode == true)
            {
                while (true == godMode) // Will perhaps freeze this script?
                {
                    GodModeEffect(); // Turn bool to false
                }
            }

        }

        public async void GodModeEffect()
        {
            health = GetALife(3); // High on life!
            await Task.Delay(10000); // Godmode for 10 sek

            health = GetALife(1); // change life back to full
            godMode = false; // This should kill the method
        }

        public bool KillPlayer()
        {
            Player.DestroyImmediate(this);
            return false;
        }

        public int GetALife(int lifeMode)
        {
            if (lifeMode == 1) // Full health
            {
                return 3;
            }
            else if (lifeMode == 0) //ishit
            {
                return health--;
            }
            else if (lifeMode == 2) // Add life
            {
                return health++;
            }
            else if (lifeMode == 3) //godmode
            {
                return 10000000;
            }
            else // just checking
            {
                return health;
            }
        }

        public int PlayerBombRange(int isStart)
        {
            if (isStart == 1) // Initial pwr
            {
                return bombStrengt = 2;
            }
            else if (isStart == 0) //increase pwr
            {
                return (bombStrengt += 1);
            }
            else return bombStrengt;
        }




    }
}

