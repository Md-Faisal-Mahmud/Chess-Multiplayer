using ChessGame.Business_Logic.rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class GameRules : IGameRules
    {
        private readonly IPawn _pawn;
        private readonly IRook _rook;
        private readonly IKnight _knight;
        private readonly IBishop _bishop;
        private readonly IQueen _queen;
        private readonly IKing _king;
        private readonly ICheck _check;
        public GameRules(IKnight knight, IRook rook, IQueen queen, IBishop bishop, IPawn pawn, IKing king, ICheck check)
        {
            _knight = knight;
            _rook = rook;
            _queen = queen;
            _bishop = bishop;
            _king = king;
            _pawn = pawn;
            _check = check;
        }


       


        public bool IsCheckMate(char[,] arr, bool isWhite)
        {

            if (!_check.IsCheck(arr, isWhite))
            {
                return false;
            }


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

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    char pieceSymbol = arr[row, col];

                    bool isOwnPiece = false;
                    if (pieceSymbol != ' ')
                    {
                        if (isWhite && pieceSymbol >= '\u2654' && pieceSymbol <= '\u2659')
                        {
                            isOwnPiece = true;
                        }
                        else if (!isWhite && pieceSymbol >= '\u265A' && pieceSymbol <= '\u265F')
                        {
                            isOwnPiece = true;
                        }
                    }

                    if (isOwnPiece)
                    {
                        List<(int, int)> moves = null;

                        switch (pieceSymbol)
                        {
                            case '\u2654':
                            case '\u265A':
                                moves = _king.GetAllValidKingMoves(arr, row, col, isWhite);
                                break;

                            case '\u2655':
                            case '\u265B':
                                moves = _queen.GetAllValidQueenMoves(arr, row, col, isWhite);
                                break;

                            case '\u2656':
                            case '\u265C':
                                moves = _rook.GetAllValidRookMoves(arr, row, col, isWhite);
                                break;

                            case '\u2657':
                            case '\u265D':
                                moves = _bishop.GetAllValidBishopMoves(arr, row, col, isWhite);
                                break;

                            case '\u2658':
                            case '\u265E':
                                moves = _knight.GetAllValidKnightMoves(arr, row, col, isWhite);
                                break;

                            case '\u2659':
                            case '\u265F':
                                moves = _pawn.GetAllValidPawnMoves(arr, row, col, isWhite, false);
                                break;
                        }

                        foreach ((int, int) move in moves)
                        {
                            char[,] tempArr = (char[,])arr.Clone();

                            tempArr[move.Item1, move.Item2] = pieceSymbol;
                            tempArr[row, col] = ' ';

                            if (!_check.IsCheck(tempArr, isWhite))
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }




        public bool IsStalemate(char[,] arr, bool isWhite)
        {
            return false;
        }

    }
}
