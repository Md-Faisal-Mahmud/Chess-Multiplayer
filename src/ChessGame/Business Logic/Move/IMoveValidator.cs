namespace ChessGame
{
    public interface IMoveValidator
    {
        char[,] MakeMove(bool isWhite, char[,] Tiles);
    }
}