using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Business_Logic.rules
{
    public class Check : ICheck
    {
        private readonly IPawn _pawn;
        private readonly IRook _rook;
        private readonly IKnight _knight;
        private readonly IBishop _bishop;
        private readonly IQueen _queen;
        private readonly IKing _king;
        public Check(IKnight knight, IRook rook, IQueen queen, IBishop bishop, IPawn pawn, IKing king)
        {
            _knight = knight;
            _rook = rook;
            _queen = queen;
            _bishop = bishop;
            _king = king;
            _pawn = pawn;
        }
        #region IsCheck
        public bool IsCheck(char[,] arr, bool isWhite)
        {
  
            int kingRow = -1;
            int kingCol = -1;
            char kingSymbol = isWhite ? '\u2654' : '\u265A';
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (arr[row, col] == kingSymbol)
                    {
                        kingRow = row;
                        kingCol = col;
                        break;
                    }
                }
            } 


            bool isCheck = false;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    isWhite = kingSymbol == '\u2654' ? true: false;             /// important
                    char pieceSymbol = arr[row, col];

                    bool isOpponentPiece = false;
                    if (pieceSymbol != ' ')
                    {
                        if (isWhite && pieceSymbol >= '\u265A' && pieceSymbol <= '\u265F')
                        {
                            isOpponentPiece = true;
                        }
                        else if (!isWhite && pieceSymbol >= '\u2654' && pieceSymbol <= '\u2659')
                        {
                            isOpponentPiece = true;
                        }
                    }

                    if (isOpponentPiece)
                    {
                        bool isValidMove = false;
                        switch (pieceSymbol)
                        {
                            case 'Ⓚ': // Knight
                            case 'K':
                                isValidMove = _knight.IsValidMove(arr, row, col, kingRow, kingCol, !isWhite, false);
                                break;
                            case '\u265D': // Bishop
                            case '\u2657':
                                isValidMove = _bishop.IsValidMove(arr, row, col, kingRow, kingCol, !isWhite, false);
                                break;
                            case '\u265C': // Rook
                            case '\u2656':
                                isValidMove = _rook.IsValidMove(arr, row, col, kingRow, kingCol, !isWhite, false);
                                break;
                            case '\u265B': // Queen
                            case '\u2655':
                                isValidMove = _queen.IsValidMove(arr, row, col, kingRow, kingCol, !isWhite, false);
                                break;
                            case '\u265A': // King
                            case '\u2654':
                                isValidMove = _king.IsValidMove(arr, row, col, kingRow, kingCol, !isWhite, false);
                                break;
                            case '\u265F': // Pawn
                            case '\u2659':
                                if (arr[row, col] == '\u2659')
                                {
                                    isWhite = true;
                                    
                                }
                                else
                                {
                                    isWhite = false;
                                }
                                isValidMove = (isWhite && row - kingRow == 1 && Math.Abs(col - kingCol) == 1) || 
                                (!isWhite && row - kingRow == -1 && Math.Abs(col - kingCol) == 1); 
                                break;
                        }
                        if (isValidMove)
                        {
                            isCheck = true;
                            return isCheck;
                        }
                    }
                }
            }
            return isCheck;
        }
        #endregion

    }
}
