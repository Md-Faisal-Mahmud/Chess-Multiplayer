using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Rook : IRook
    {
        private readonly IPieceColorDetector _pieceColorDetector;

        public Rook(IPieceColorDetector pieceColorDetector)
        {
            _pieceColorDetector = pieceColorDetector;
        }



        public  List<(int, int)> GetAllValidRookMoves(char[,] arr, int row, int col, bool isWhite)
        {
            List<(int, int)> moves = new List<(int, int)>();

            for (int c = col - 1; c >= 0; c--)
            {
                if (arr[row, c] == ' ')
                {
                    moves.Add((row, c));
                }
                else
                {
                    if (_pieceColorDetector.IsOpponentPiece(arr[row, c], isWhite))
                    {
                        moves.Add((row, c));
                    }
                    break;
                }
            }

            for (int c = col + 1; c < 8; c++)
            {
                if (arr[row, c] == ' ')
                {
                    moves.Add((row, c));
                }
                else
                {
                    if (_pieceColorDetector.IsOpponentPiece(arr[row, c], isWhite))
                    {
                        moves.Add((row, c));
                    }
                    break;
                }
            }


            for (int r = row - 1; r >= 0; r--)
            {
                if (arr[r, col] == ' ')
                {
                    moves.Add((r, col));
                }
                else
                {
                    if (_pieceColorDetector.IsOpponentPiece(arr[r, col], isWhite))
                    {
                        moves.Add((r, col));
                    }
                    break;
                }
            }

            for (int r = row + 1; r < 8; r++)
            {
                if (arr[r, col] == ' ')
                {
                    moves.Add((r, col));
                }
                else
                {
                    if (_pieceColorDetector.IsOpponentPiece(arr[r, col], isWhite))
                    {
                        moves.Add((r, col));
                    }
                    break;
                }
            }

            return moves;
        }



        public bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove)
        {
            int rowDelta = newRow - currentRow;
            int colDelta = newCol - currentCol;


            if (rowDelta != 0 && colDelta != 0)
            {
                return false;
            }


            if (rowDelta != 0)
            {
                int rowDirection = rowDelta > 0 ? 1 : -1;
                for (int i = currentRow + rowDirection; i != newRow; i += rowDirection)
                {
                    if (arr[i, currentCol] != ' ')
                    {
                        return false;
                    }
                }
            }
            else if (colDelta != 0)
            {
                int colDirection = colDelta > 0 ? 1 : -1;
                for (int i = currentCol + colDirection; i != newCol; i += colDirection)
                {
                    if (arr[currentRow, i] != ' ')
                    {
                        return false;
                    }
                }
            }

            if (arr[newRow, newCol] == ' ' || (isWhite ? _pieceColorDetector.IsBlackPiece(arr[newRow, newCol]) : _pieceColorDetector.IsWhitePiece(arr[newRow, newCol])))
            {
                return true;
            }

            return false;
        }


    }
}
