using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public interface IPieceColorDetector
    {
        bool IsWhitePiece(char piece);
        bool IsBlackPiece(char piece);
        bool IsOpponentPiece(char piece, bool isWhite);
    }
}
