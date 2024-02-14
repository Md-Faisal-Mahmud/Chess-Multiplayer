namespace ChessGame
{
    public interface IRook
    {
        List<(int, int)> GetAllValidRookMoves(char[,] arr, int row, int col, bool isWhite);
        bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove);
    }
}