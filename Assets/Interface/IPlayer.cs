using System.Collections.Generic;

namespace GameContent.Interface
{
    public interface IPlayer
    {
        abstract void PlaceBombRequest(Element[,]? gameBoard);

        abstract void UseItem();
    }
}

