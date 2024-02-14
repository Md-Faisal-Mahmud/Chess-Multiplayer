namespace ChessGame
{
    public interface IKnight
    {
        List<(int, int)> GetAllValidKnightMoves(char[,] arr, int row, int col, bool isWhite);
        bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove);
    }
}