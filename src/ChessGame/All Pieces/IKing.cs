namespace ChessGame
{
    public interface IKing
    {
        List<(int, int)> GetAllValidKingMoves(char[,] arr, int row, int col, bool isWhite);
        bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove);
        bool CanCastle(char[,] arr, bool isWhite);     /// not implemented yet
    }
}