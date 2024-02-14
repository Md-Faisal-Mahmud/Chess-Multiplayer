using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public interface IBoard<T>
    {
        T Tiles { get; set; }
        void SetAllPieces();
        void SetTiles(T tiles);
        //T GetTiles();

    }
}
