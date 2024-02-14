using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class PieceColorDetector : IPieceColorDetector
    {
        public bool IsWhitePiece(char piece)
        {
            return piece == '\u2654' || piece == '\u2655' || piece == '\u2656' || piece == '\u2657' || piece == 'K' || piece == '\u2659';
        }

        public bool IsBlackPiece(char piece)
        {
            return piece == '\u265A' || piece == '\u265B' || piece == '\u265C' || piece == '\u265D' || piece == 'Ⓚ' || piece == '\u265F';
        }



        public bool IsOpponentPiece(char piece, bool isWhite)
        {
            if (piece == ' ') 
            {
                return false;
            }
            if (isWhite && (piece >= '\u265A' && piece <= '\u265F')) 
            {
                return true;
            }
            if (!isWhite && (piece >= '\u2654' && piece <= '\u2659')) 
            {
                return true;
            }

            return false; 
        }          // tested


    }

}
