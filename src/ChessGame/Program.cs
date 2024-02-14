using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace ChessGame
{
    public class Program
    {
        private static IChessGameController _chessGameController;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new ChessModule());
            var container = containerBuilder.Build();
            _chessGameController = container.Resolve<IChessGameController>();

            _chessGameController.StartGame();
        }
    }
}

