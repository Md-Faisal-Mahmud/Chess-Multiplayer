using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChessGame
{
    public class InputHandler : IInputHandler 
    {
       private readonly IInputParser _inputParser;

        public InputHandler(IInputParser inputParser)
        {
            _inputParser = inputParser;
        }

        private bool InputFormatChecker(string pieceSelected)
        {
            
            if (string.IsNullOrWhiteSpace(pieceSelected) || !Regex.IsMatch(pieceSelected, "^[a-h][1-8]$"))
            {
                Console.WriteLine("Invalid input format. Please enter (a-h) & (1-8). Ex: a1, h8");
                
                return false;
            }
            return true;
      
        }


        public int[] GetSourceInput()
        {
            int[] source = null;
            while (source == null)
            {
                Console.WriteLine("Enter src :");
                string pieceSource = Console.ReadLine();

               if (!InputFormatChecker(pieceSource))
                {
                    continue;
                }

                source = _inputParser.MapInputToIndex(pieceSource);
            }
            return source;
        }

        public int[] GetDestinationInput()
        {
            int[] destination = null;
            while (destination == null)
            {
                Console.WriteLine("Enter des :");
                string pieceDestination = Console.ReadLine();

                if (!InputFormatChecker(pieceDestination))
                {
                    continue;
                }

                destination = _inputParser.MapInputToIndex(pieceDestination);
            }
            return destination;
        }
        
        public bool IsValidUserInput(char[,] arr, int currentRow, int currentCol, int newRow, int newCol, bool isWhite, bool isFirstMove)
        {
            return false;
        }
    }
}
