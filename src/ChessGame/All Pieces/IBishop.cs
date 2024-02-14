namespace ChessGame
{
    public interface IBishop
    {
        List<(int, int)> GetAllValidBishopMoves(char[,] arr, int row, int col, bool isWhite);
        bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove);

    }
}