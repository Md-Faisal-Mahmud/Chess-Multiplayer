using ChessGame.Business_Logic.rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ChessGame
{
    public class MoveValidator : IMoveValidator 
    {
        private readonly IInputHandler _inputHandler;
        private readonly IPawn _pawn;
        private readonly IRook _rook;
        private readonly IKnight _knight; 
        private readonly IBishop _bishop;
        private readonly IQueen _queen;
        private readonly IKing _king;
        private readonly ICheck _check;
        private readonly ITwoDPrinter _twoDprinter;
        
        public MoveValidator(IInputHandler inputHandler, IPawn pawn, IRook rook, IKnight knight, IBishop bishop, IQueen queen, IKing king, ICheck check, ITwoDPrinter twoDPrinter)
        {
            _inputHandler = inputHandler;
            _pawn = pawn;
            _rook = rook;
            _knight = knight;
            _bishop = bishop;
            _queen = queen;
            _king = king;
            _check = check;
            _twoDprinter = twoDPrinter;
        }


        public char[,] MakeMove(bool isWhite, char[,] Tiles)
        {
            string player = isWhite ? '\u26A1' + "WHITE PLAYER'S TURN" + '\u26A1' : '\u26A1' + "BLACK PLAYER'S TURN" + '\u26A1';
            Console.WriteLine(player);
            var source = _inputHandler.GetSourceInput();
            var destination = _inputHandler.GetDestinationInput();


            int currentRow = source[0];
            int currentCol = source[1];
            int newRow = destination[0];
            int newCol = destination[1];


            bool isFirstMove = false;


            Func<char[,], int, int, int, int, bool, bool, bool> pieceType;

            char piece = Tiles[source[0], source[1]];



            if (piece == '\u2659' || piece == '\u265F')                           ///  Pawn
            {
                pieceType = _pawn.IsValidMove;

            }
            else if (piece == '\u2656' || piece == '\u265C')                       ///  Rook
            {
                pieceType = _rook.IsValidMove;
            }
            else if (piece == '\u265E' || piece == '\u2658')                       ///  Knight
            {
                pieceType = _knight.IsValidMove;
            }
            else if (piece == '\u265D' || piece == '\u2657')                       ///  Bishop
            {
                pieceType = _bishop.IsValidMove;
            }
            else if (piece == '\u265B' || piece == '\u2655')                       ///  Queen
            {
                pieceType = _queen.IsValidMove;
            }
            else if (piece == '\u265A' || piece == '\u2654')                        ///  King
            {
                pieceType = _king.IsValidMove;
            }
            else
            {
                pieceType = _inputHandler.IsValidUserInput;
            }


            if (pieceType(Tiles, currentRow, currentCol, newRow, newCol, isWhite, isFirstMove))
            {
              

                // Make move
                Tiles[destination[0], destination[1]] = Tiles[source[0], source[1]];
                Tiles[source[0], source[1]] = ' ';
                if (_check.IsCheck(Tiles, isWhite))
                {
                    Console.WriteLine("Your king is being checked by opponent. Invalid input.");
                    Tiles[source[0], source[1]] = Tiles[destination[0], destination[1]];
                    Tiles[destination[0], destination[1]] = ' ';
                    MakeMove(isWhite, Tiles);
                }
                else
                {
                    Console.Clear();
                    //Console.WriteLine("Valid Move");
                }
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
                MakeMove(isWhite, Tiles);
            }
            return Tiles;

        }
    }
}
