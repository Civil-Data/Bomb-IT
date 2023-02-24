using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLogic
{
    public abstract class Player
    {
        public int NBomb { get; set; }
        public int Id { get; set; } // Do we need this?
        public int BombStrengt { get; set; }
        public int Health { get; set; }
        public float Speed { get; set; }
        public bool IsAlive { get; set; }
        public bool GodMode { get; set; }
        public bool StrongBoi { get; set; } = false;
        public int X { get; set; }
        public int Y { get; set; }

        /*
        // Start is called before the first frame update
        void Start()
        {
            Health = GetALife(1);
            BombStrengt = PlayerBombRange(1);
        }

        // Update is called once per frame
        void Update()
        {
            //BombStrengt = PlayerBombRange(0); // check range
            /*
            if (Health == 0) //isDead
            {
                IsAlive = KillPlayer();
            }
            */
        /*
            if (GodMode == true)
            {
                while (true == GodMode) // Will perhaps freeze this script?
                {
                    GodModeEffect(); // Turn bool to false
                }
            }

        }
        */
        public async void GodModeEffect()
        {
            Health = GetALife(3); // High on life!
            await Task.Delay(10000); // Godmode for 10 sek

            Health = GetALife(1); // change life back to full
            GodMode = false; // This should kill the method
        }
        /*
        public bool KillPlayer()
        {
            HumanPlayer.DestroyImmediate(this);
            return false;
        }
        */
        public int GetALife(int lifeMode)
        {
            if (lifeMode == 1) // Full Health
            {
                return 3;
            }
            else if (lifeMode == 0) //ishit
            {
                return Health--;
            }
            else if (lifeMode == 2) // Add life
            {
                return Health++;
            }
            else if (lifeMode == 3) //godmode
            {
                return 10000000;
            }
            else // just checking
            {
                return Health;
            }
        }

        public int PlayerBombRange(int isStart)
        {
            if (isStart == 1) // Initial pwr
            {
                return BombStrengt = 2;
            }
            else if (isStart == 0) //increase pwr
            {
                return (BombStrengt += 1);
            }
            else return BombStrengt;
        }




    }
}

