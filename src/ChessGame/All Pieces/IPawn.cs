namespace ChessGame
{
    public interface IPawn
    {
        List<(int, int)> GetAllValidPawnMoves(char[,] arr, int row, int col, bool isWhite, bool isFirstMove);
        bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove);
        bool PawnPromotion();   /// not implemented yet
    }
}