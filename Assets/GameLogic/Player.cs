using System.Collections.Generic;

namespace GameLogic
{
    public abstract class Player
    {
        public List<Bomb> n_Bomb { get; set; }
        public float speed { get; set; }
        public bool godMode { get; set; }
        public bool strongBoi { get; set; } = false;

        public int X { get; set; }

        public int Y { get; set; }

        public abstract void PlaceBombRequest(Element[,]? gameBoard);

        public abstract void UseItem();
    }
}

