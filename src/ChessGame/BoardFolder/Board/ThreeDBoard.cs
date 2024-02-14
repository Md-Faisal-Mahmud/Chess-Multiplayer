using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame;

namespace ChessGame
{

    public class ThreeDBoard : IBoard<char[,,]>
    {
        public const int x = 8;
        public const int y = 8;
        public const int z = 8;

        public char[,,] Tiles { get; set; } = new char[x, y, z];

    
        //public char[,,] GetTiles()
        //{
        //    throw new NotImplementedException();
        //}

        public void SetAllPieces()
        {
            throw new NotImplementedException();
        }

        public void SetTiles(char[,,] tiles)
        {
            throw new NotImplementedException();
        }
    }
}
