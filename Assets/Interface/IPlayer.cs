using System.Collections.Generic;

namespace GameContent
{
    public interface IPlayer
    {
        int NBombs { get; set; }
        float Speed { get; set; }
        bool GodMode { get; set; }
        bool StrongBoi { get; set; }

        int X { get; set; }
        int Y { get; set; }

        abstract void PlaceBombRequest(Element[,]? gameBoard);

        abstract void UseItem();
    }
}

