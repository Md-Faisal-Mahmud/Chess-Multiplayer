using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChessGame
{
    public class King : IKing
    {
        private readonly IPieceColorDetector _pieceColorDetector;
        public King(IPieceColorDetector pieceColorDetector)
        {
            _pieceColorDetector = pieceColorDetector;
        }
        public bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove)
        {
            int rowDelta = Math.Abs(newRow - currentRow);
            int colDelta = Math.Abs(newCol - currentCol);

            if (rowDelta > 1 || colDelta > 1)
            {
                return false;
            }

            if (arr[newRow, newCol] == ' ' || (isWhite && arr[newRow, newCol] >= '\u265A' && arr[newRow, newCol] <= '\u265F') || (!isWhite && arr[newRow, newCol] >= '\u2654' && arr[newRow, newCol] <= '\u2659'))
            {
                return true;
            }

            return false;
        }

        public bool CanCastle(char[,] arr, bool isWhite)
        {
            return false;  // Not implemented
        }

        public List<(int, int)> GetAllValidKingMoves(char[,] arr, int row, int col, bool isWhite)
        {
            List<(int, int)> moves = new List<(int, int)>();

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < 8 && j >= 0 && j < 8 && (i != row || j != col))
                    {
                        char piece = arr[i, j];
                        if (piece == ' ' || _pieceColorDetector.IsOpponentPiece(piece, isWhite))
                        {
                            moves.Add((i, j));
                        }
                    }
                }
            }
            return moves;
        }


    }
}
