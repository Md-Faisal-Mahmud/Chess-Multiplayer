using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Pawn : IPawn
    {
        private readonly IPieceColorDetector _pieceColorDetector;
        public Pawn(IPieceColorDetector pieceColorDetector)
        {
            _pieceColorDetector = pieceColorDetector;
        }
        public  List<(int, int)> GetAllValidPawnMoves(char[,] arr, int row, int col, bool isWhite, bool isFirstMove)        // tested
        {
            List<(int, int)> moves = new List<(int, int)>();

            int direction = isWhite ? -1 : 1; 
            int startRow = isWhite ? 6 : 1;   
            int endRow = isWhite ? 0 : 7;     

           
            int newRow = row + direction;
            if (newRow >= 0 && newRow <= 7 && arr[newRow, col] == ' ')
            {
                moves.Add((newRow, col));
                if (isFirstMove)
                {
                    newRow = row + 2 * direction;
                    if (newRow >= 0 && newRow <= 7 && arr[newRow, col] == ' ')
                    {
                        moves.Add((newRow, col));
                    }
                }
            }

            // Capture diagonally
            if (col > 0 && arr[row + direction, col - 1] != ' ' && _pieceColorDetector.IsOpponentPiece(arr[row + direction, col - 1], isWhite))
            {
                moves.Add((row + direction, col - 1));
            }
            if (col < 7 && arr[row + direction, col + 1] != ' ' && _pieceColorDetector.IsOpponentPiece(arr[row + direction, col + 1], isWhite))
            {
                moves.Add((row + direction, col + 1));
            }

            return moves;
        }


        public bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove)
        {

            if (currentRow == 6 && isWhite == true)
            {
                isFirstMove = true;
            }
            if (currentRow == 1 && isWhite == false)
            {
                isFirstMove = true;
            }


            int moveDirection = isWhite ? -1 : 1;
            int rowDelta = newRow - currentRow;
            int colDelta = Math.Abs(newCol - currentCol);


            if (rowDelta * moveDirection <= 0)
            {
                return false;
            }


            int maxMoveDistance = isFirstMove ? 2 : 1;


            if (colDelta == 1 && rowDelta == moveDirection && (arr[newRow, newCol] == ' '))
            {
                return false;
            }



            if (isWhite)
            {
                if (colDelta == 1 && rowDelta == moveDirection &&  
              ((arr[newRow, newCol] == '\u265C') ||
              (arr[newRow, newCol] == 'Ⓚ') ||
              (arr[newRow, newCol] == '\u265D') ||
              (arr[newRow, newCol] == '\u265B') ||
              (arr[newRow, newCol] == '\u265A') ||
              (arr[newRow, newCol] == '\u265F')))
                {
                    return true;
                }
            }
            else
            {
                if (colDelta == 1 && rowDelta == moveDirection && 
              ((arr[newRow, newCol] == '\u2656') ||
              (arr[newRow, newCol] == 'K') ||
              (arr[newRow, newCol] == '\u2657') ||
              (arr[newRow, newCol] == '\u2655') ||
              (arr[newRow, newCol] == '\u2654') ||
              (arr[newRow, newCol] == '\u2659')))
                {
                    return true;
                }
            }


         

            if (isFirstMove)
            {
                if ((Math.Abs(rowDelta) == 1 || Math.Abs(rowDelta) == 2) && (arr[newRow, newCol] == ' ') && colDelta == 0)    //  pawn 1 ba 2 ghor + faka ase kina
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ((Math.Abs(rowDelta) == 1) && (arr[newRow, newCol] == ' ') && colDelta == 0)    //  pawn 1 ba 2 ghor + faka ase kina
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool PawnPromotion()
        {
            throw new NotImplementedException();
        }
    }


}
