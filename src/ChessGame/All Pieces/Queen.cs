using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Queen : IQueen
    {
        private readonly IBishop _bishop;
        private readonly IRook _rook;

        public Queen(IBishop bishop, IRook rook)
        {
            _bishop = bishop;
            _rook = rook;
        }



        public  List<(int, int)> GetAllValidQueenMoves(char[,] arr, int row, int col, bool isWhite)
        {
            List<(int, int)> moves = new List<(int, int)>();


            moves.AddRange(_rook.GetAllValidRookMoves(arr, row, col, isWhite));

            moves.AddRange(_bishop.GetAllValidBishopMoves(arr, row, col, isWhite));

            return moves;
        }


        public bool IsValidMove(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove)
        {

            if (_bishop.IsValidMove(arr, currentRow, currentCol, newRow, newCol, isWhite, isFirstMove))
            {
                return true;
            }

            if (_rook.IsValidMove(arr, currentRow, currentCol, newRow, newCol, isWhite, isFirstMove))
            {
                return true;
            }

         
            return false;
        }
    }
}
