namespace GameLogic
{
    public interface IPlayer
    {
        void PlaceBombRequest(Element[,]? gameBoard);

        void UseItem();
    }
}

