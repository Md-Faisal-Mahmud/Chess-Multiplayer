namespace ChessGame
{
    public interface IInputHandler
    {
        
        int[] GetDestinationInput();
        int[] GetSourceInput();
        bool IsValidUserInput(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove);
    }
}