using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class BoardPrinter : ITwoDPrinter, IThreeDPrinter
    {
        

        #region 2D
        public void PrintTwoDBoard(char[,] arr)
        {
            var TwoDTiles = arr;
            
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if ((row + col) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    if (TwoDTiles[row, col] == '\u265F'
                        || TwoDTiles[row, col] == '\u265C'
                        || TwoDTiles[row, col] == '\u265E'
                        || TwoDTiles[row, col] == '\u265D'
                        || TwoDTiles[row, col] == '\u265B' // black queen
                        || TwoDTiles[row, col] == '\u265A' // black king
                        || TwoDTiles[row, col] == '\u265D' // black bishop
                        || TwoDTiles[row, col] == '\u265E' // black knight
                        || TwoDTiles[row, col] == '\u265C') // black rook
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    if (TwoDTiles[row, col] == '\u2659'
                        || TwoDTiles[row, col] == '\u2656'  // white rook 
                        || TwoDTiles[row, col] == '\u2658' // white knight
                        || TwoDTiles[row, col] == '\u2657' // white bishop
                        || TwoDTiles[row, col] == '\u2655' // white queen
                        || TwoDTiles[row, col] == '\u2654' // white king
                        || TwoDTiles[row, col] == '\u2657' // white bishop
                        || TwoDTiles[row, col] == '\u2658' // white knight
                        || TwoDTiles[row, col] == '\u2656') // white rook
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(" {0} ", TwoDTiles[row, col]);

                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        #endregion





        #region 3D
        // not implemented
        public void PrintThreeDBoard()
        {
            throw new NotImplementedException();
        }
        
        #endregion








    }
}
