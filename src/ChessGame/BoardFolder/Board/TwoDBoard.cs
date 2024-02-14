using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class TwoDBoard : IBoard<char[,]>
    {
        public const int Height = 8;
        public const int Width = 8;

        public char[,] Tiles { get; set; } = new char[Height, Width];
        public TwoDBoard()
        {
            SetAllPieces();
        }

        //public char[,] GetTiles()
        //{
        //    return Tiles;
        //}

        public void SetTiles(char[,] tiles)
        {
            Tiles = tiles;
        }
        public void SetAllPieces()
        {
         
            Tiles[0, 0] = '\u265C'; // black rook
            Tiles[0, 1] = 'Ⓚ'; // black knight
            Tiles[0, 2] = '\u265D'; // black bishop
            Tiles[0, 3] = '\u265B'; // black queen
            Tiles[0, 4] = '\u265A'; // black king
            Tiles[0, 5] = '\u265D'; // black bishop
            //Tiles[0, 6] = '\u265E'; // black knight
            Tiles[0, 6] = 'Ⓚ'; // black knight
            Tiles[0, 7] = '\u265C'; // black rook


            for (int col = 0; col < Height; col++)
            {
                Tiles[1, col] = '\u265F'; // black pawn
            }
            for (int row = 2; row < 6; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Tiles[row, col] = ' ';
                }

            }

            // initialize the white pieces
            Tiles[7, 0] = '\u2656'; // white rook
            Tiles[7, 1] = 'K'; // white knight
            Tiles[7, 2] = '\u2657'; // white bishop
            Tiles[7, 3] = '\u2655'; // white queen
            Tiles[7, 4] = '\u2654'; // white king
            Tiles[7, 5] = '\u2657'; // white bishop
            //Tiles[7, 6] = '\u2658'; // white knight
            Tiles[7, 6] = 'K'; // white knight
            Tiles[7, 7] = '\u2656'; // white rook

            for (int col = 0; col < Height; col++)
            {
                Tiles[6, col] = '\u2659'; // white pawn
            }
        }

     
    }
}
