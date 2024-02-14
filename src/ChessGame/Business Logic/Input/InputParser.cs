using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class InputParser : IInputParser
    {
        public int[] MapInputToIndex(string input)
        {
            int[] indices = new int[2];
            Dictionary<char, int> columnMap = new Dictionary<char, int>
            {
                 { 'a', 0 },
                 { 'b', 1 },
                 { 'c', 2 },
                 { 'd', 3 },
                 { 'e', 4 },
                 { 'f', 5 },
                 { 'g', 6 },
                 { 'h', 7 }
            };

     
            indices[1] = columnMap[input[0]];

            indices[0] = 8 - (int)char.GetNumericValue(input[1]);

            return indices;
        }


    }
}
