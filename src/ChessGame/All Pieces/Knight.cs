using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Knight : IKnight
    {
        private readonly IPieceColorDetector _pieceColorDetector;
        public Knight(IPieceColorDetector pieceColorDetector)
        {
            _pieceColorDetector = pieceColorDetector;
        }
        public List<(int, int)> GetAllValidKnightMoves(char[,] arr, int row, int col, bool isWhite)
        {
            List<(int, int)> moves = new List<(int, int)>();

            int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
            int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };

            for (int i = 0; i < dx.Length; i++)
            {
                int newRow = row + dx[i];
                int newCol = col + dy[i];

                if (newRow >= 0 && newRow <= 7 && newCol >= 0 && newCol <= 7)
                {
                    if (arr[newRow, newCol] == ' ' || _pieceColorDetector.IsOpponentPiece(arr[newRow, newCol], isWhite))
                    {
                        moves.Add((newRow, newCol));
                    }
                }
            }

            return moves;
        }


        public bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove)
        {
            int rowDelta = Math.Abs(newRow - currentRow);
            int colDelta = Math.Abs(newCol - currentCol);

            if ((rowDelta == 2 && colDelta == 1) || (rowDelta == 1 && colDelta == 2))
            {
                if (arr[newRow, newCol] == ' ' || (isWhite && arr[newRow, newCol] >= '\u265A' && arr[newRow, newCol] <= '\u265F') ||
                    (!isWhite && arr[newRow, newCol] >= '\u2654' && arr[newRow, newCol] <= '\u2659'))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
