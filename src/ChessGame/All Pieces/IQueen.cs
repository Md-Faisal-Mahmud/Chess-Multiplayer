namespace ChessGame
{
    public interface IQueen
    {
        List<(int, int)> GetAllValidQueenMoves(char[,] arr, int row, int col, bool isWhite);
        bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove);
    }
}