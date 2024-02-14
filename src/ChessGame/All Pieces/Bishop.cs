using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Bishop : IBishop
    {
        private readonly IPieceColorDetector _pieceColorDetector;
        public Bishop(IPieceColorDetector pieceColorDetector)
        {
            _pieceColorDetector = pieceColorDetector;   
        }
        public bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove)
        {
            int rowDelta = newRow - currentRow;
            int colDelta = (newCol - currentCol);

            // moves diagonally
            if (Math.Abs(rowDelta) != Math.Abs(colDelta))
            {
                return false;
            }


            int moveDirectionRow = rowDelta > 0 ? 1 : -1;
            int moveDirectionCol = colDelta > 0 ? 1 : -1;

            int checkRow = currentRow + moveDirectionRow;
            int checkCol = currentCol + moveDirectionCol;

            while (checkRow != newRow && checkCol != newCol)
            {
                if (arr[checkRow, checkCol] != ' ')
                {
                    return false;
                }

                checkRow += moveDirectionRow;
                checkCol += moveDirectionCol;
            }

            // capturing an enemy piece
            if (arr[newRow, newCol] != ' ' && (isWhite && arr[newRow, newCol] >= '\u265A' && arr[newRow, newCol] <= '\u265F') ||
                (!isWhite && arr[newRow, newCol] >= '\u2654' && arr[newRow, newCol] <= '\u2659'))
            {
                return true;
            }

    
            return arr[newRow, newCol] == ' ';
        }





        #region GetAllValidBishopMoves
        public  List<(int, int)> GetAllValidBishopMoves(char[,] arr, int row, int col, bool isWhite)
        {
            List<(int, int)> moves = new List<(int, int)>();

            // Check valid diagonal moves in all directions
            int[,] directions = { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
            for (int i = 0; i < 4; i++)
            {
                int dRow = directions[i, 0];
                int dCol = directions[i, 1];

                int newRow = row + dRow;
                int newCol = col + dCol;

                while (newRow >= 0 && newRow <= 7 && newCol >= 0 && newCol <= 7)
                {
                    if (arr[newRow, newCol] == ' ')
                    {
                        moves.Add((newRow, newCol));
                    }
                    else
                    {
                        // Capture if the piece is an opponent's piece
                        if (_pieceColorDetector.IsOpponentPiece(arr[newRow, newCol], isWhite))
                        {
                            moves.Add((newRow, newCol));
                        }
                        break;
                    }

                    newRow += dRow;
                    newCol += dCol;
                }
            }

            return moves;
        }
        #endregion


    }
}
