using Autofac;
using ChessGame.Business_Logic.rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class ChessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BoardPrinter>().As<ITwoDPrinter>();
            builder.RegisterType<TwoDBoard>().As<IBoard<char[,]>>();
            builder.RegisterType<MoveValidator>().As<IMoveValidator>();


            builder.RegisterType<InputHandler>().As<IInputHandler>();
            builder.RegisterType<InputParser>().As<IInputParser>();
            builder.RegisterType<Check>().As<ICheck>();


            builder.RegisterType<Pawn>().As<IPawn>();
            builder.RegisterType<Rook>().As<IRook>();
            builder.RegisterType<Knight>().As<IKnight>();
            builder.RegisterType<Bishop>().As<IBishop>();
            builder.RegisterType<Queen>().As<IQueen>();
            builder.RegisterType<King>().As<IKing>();
            
            
            builder.RegisterType<PieceColorDetector>().As<IPieceColorDetector>();
            builder.RegisterType<GameRules>().As<IGameRules>();
            builder.RegisterType<ChessGameController>().As<IChessGameController>();

        }
    }
}
