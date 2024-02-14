namespace ChessGame
{
    public interface IGameRules
    {
        bool IsCheckMate(char[,] arr, bool isWhite);
        bool IsStalemate(char[,] arr, bool isWhite);     // incomplete
    }
}