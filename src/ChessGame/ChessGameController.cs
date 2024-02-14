using Autofac;
using ChessGame.Business_Logic.rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class ChessGameController : IChessGameController
    {
        public void StartGame()
        {

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new ChessModule());
            IContainer container = builder.Build();
            var board = container.Resolve<IBoard<char[,]>>();
            board.SetAllPieces();
            var printer = container.Resolve<ITwoDPrinter>();
            printer.PrintTwoDBoard(board.Tiles);
            var gameRules = container.Resolve<IGameRules>();
            var moveValidator = container.Resolve<IMoveValidator>();
            var check = container.Resolve<ICheck>();

            bool isWhite = true;
            bool isCheck = false;
            bool w = true;
            while (w)
            {
                if (isWhite)
                {
                    if (gameRules.IsCheckMate(board.Tiles, isWhite))
                    {
                        Console.WriteLine("Black Winner !");
                        w = false;
                    }
                    else
                    {
                        isCheck = check.IsCheck(board.Tiles, isWhite);
                        if (isCheck)
                        {
                            Console.WriteLine("Warning ! White king is under check !");
                        }
                        moveValidator.MakeMove(isWhite, board.Tiles);
                        board.SetTiles(board.Tiles);

                        printer.PrintTwoDBoard(board.Tiles);
                        isWhite = false;
                    }
                }
                else
                {
                    if (gameRules.IsCheckMate(board.Tiles, isWhite))
                    {
                        Console.WriteLine("White Winner !");
                        w = false;
                    }
                    else
                    {
                        isCheck = check.IsCheck(board.Tiles, isWhite);
                        if (isCheck)
                        {
                            Console.WriteLine("Warning ! Black king is under Check !");
                        }
                        moveValidator.MakeMove(isWhite, board.Tiles);
                        printer.PrintTwoDBoard(board.Tiles);
                        isWhite = true;
                    }

                }

            }


        }

    }
}
