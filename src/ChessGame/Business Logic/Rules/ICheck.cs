namespace ChessGame.Business_Logic.rules
{
    public interface ICheck
    {
        bool IsCheck(char[,] arr, bool isWhite);
    }
}