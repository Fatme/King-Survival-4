using System;
using System.Collections.Generic;
using KingSurvival.Board;
using KingSurvival.Board.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival.Players;
using KingSurvival.Figures;
using KingSurvival.Commands;
using KingSurvival.Figures.Contracts;
using KingSurvival.FigureFactory;
using KingSurvival.Players.Contracts;

namespace UnitTests
{
    [TestClass]
    public class PawnPlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfTheMoveMethodThrowsCorrectlyWhenTheCommandIsNotExactlyThreeSymbols()
        {
            List<IPlayer> players = new List<IPlayer>();
            players.Add(new PawnPlayer("pawn"));
            players.Add(new KingPlayer("king"));
            IBoard board = new Board();
            var firstPlayer = players[0];
            IFigure king = new KingFigureFactory().CreateFigure(FigureSign.K);
            firstPlayer.AddFigure(king);
            board.AddFigure(king, new Position(Constants.InitialKingRow, Constants.InitialKingColumn));

            var secondPlayer = players[1];
            IFigure pawnA = new PawnFigureFactory().CreateFigure(FigureSign.A);
            IFigure pawnB = new PawnFigureFactory().CreateFigure(FigureSign.B);
            IFigure pawnC = new PawnFigureFactory().CreateFigure(FigureSign.C);
            IFigure pawnD = new PawnFigureFactory().CreateFigure(FigureSign.D);
            secondPlayer.AddFigure(pawnA);
            secondPlayer.AddFigure(pawnB);
            secondPlayer.AddFigure(pawnC);
            secondPlayer.AddFigure(pawnD);
            board.AddFigure(pawnA, new Position(Constants.PawnAInitialRow, Constants.PawnAInitialCol));
            board.AddFigure(pawnB, new Position(Constants.PawnBInitialRow, Constants.PawnBInitialCol));
            board.AddFigure(pawnC, new Position(Constants.PawnCInitialRow, Constants.PawnCInitialCol));
            board.AddFigure(pawnD, new Position(Constants.PawnDInitialRow, Constants.PawnDInitialCol));

            secondPlayer.Move(new Command("shshs", new List<string>()), board);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfTheMoveMethodThrowsCorrectlyIfTheCommandIsThreeSymbolsLongButStillNotCorrect()
        {
            //var player = new PawnPlayer("Serafim");
            //IFigure pawnA = new PawnA().CreateFigure();
            //IFigure pawnB = new PawnB().CreateFigure();
            //IFigure pawnC = new PawnC().CreateFigure();
            //IFigure pawnD = new PawnD().CreateFigure();
            //player.AddFigure(pawnA);
            //player.AddFigure(pawnB);
            //player.AddFigure(pawnC);
            //player.AddFigure(pawnD);

            //player.Move("aaa");
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheAdrCommand()
        {
            //var player = new PawnPlayer("Serafim");
            //IFigure pawnA = new PawnA().CreateFigure();
            //IFigure pawnB = new PawnB().CreateFigure();
            //IFigure pawnC = new PawnC().CreateFigure();
            //IFigure pawnD = new PawnD().CreateFigure();
            //player.AddFigure(pawnA);
            //player.AddFigure(pawnB);
            //player.AddFigure(pawnC);
            //player.AddFigure(pawnD);

            //var position = new Position(1, 1);
            //var to = player.Move("adr").To;

            //Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheBdrCommand()
        {
            //var player = new PawnPlayer("Serafim");
            //IFigure pawnA = new PawnA().CreateFigure();
            //IFigure pawnB = new PawnB().CreateFigure();
            //IFigure pawnC = new PawnC().CreateFigure();
            //IFigure pawnD = new PawnD().CreateFigure();
            //player.AddFigure(pawnA);
            //player.AddFigure(pawnB);
            //player.AddFigure(pawnC);
            //player.AddFigure(pawnD);

            //var position = new Position(1, 3);
            //var to = player.Move("bdr").To;

            //Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheCdrCommand()
        {
            //var player = new PawnPlayer("Serafim");
            //IFigure pawnA = new PawnA().CreateFigure();
            //IFigure pawnB = new PawnB().CreateFigure();
            //IFigure pawnC = new PawnC().CreateFigure();
            //IFigure pawnD = new PawnD().CreateFigure();
            //player.AddFigure(pawnA);
            //player.AddFigure(pawnB);
            //player.AddFigure(pawnC);
            //player.AddFigure(pawnD);

            //var position = new Position(1, 5);
            //var to = player.Move("cdr").To;

            //Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheDdrCommand()
        {
            //var player = new PawnPlayer("Serafim");
            //IFigure pawnA = new PawnA().CreateFigure();
            //IFigure pawnB = new PawnB().CreateFigure();
            //IFigure pawnC = new PawnC().CreateFigure();
            //IFigure pawnD = new PawnD().CreateFigure();
            //player.AddFigure(pawnA);
            //player.AddFigure(pawnB);
            //player.AddFigure(pawnC);
            //player.AddFigure(pawnD);

            //var position = new Position(1, 7);
            //var to = player.Move("ddr").To;

            //Assert.AreEqual(to, position);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheAdlCommand()
        {
            //var player = new PawnPlayer("Serafim");
            //IFigure pawnA = new PawnA().CreateFigure();
            //IFigure pawnB = new PawnB().CreateFigure();
            //IFigure pawnC = new PawnC().CreateFigure();
            //IFigure pawnD = new PawnD().CreateFigure();
            //player.AddFigure(pawnA);
            //player.AddFigure(pawnB);
            //player.AddFigure(pawnC);
            //player.AddFigure(pawnD);

            //player.Move("adl");
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheBdlCommand()
        {
            //var player = new PawnPlayer("Serafim");
            //IFigure pawnA = new PawnA().CreateFigure();
            //IFigure pawnB = new PawnB().CreateFigure();
            //IFigure pawnC = new PawnC().CreateFigure();
            //IFigure pawnD = new PawnD().CreateFigure();
            //player.AddFigure(pawnA);
            //player.AddFigure(pawnB);
            //player.AddFigure(pawnC);
            //player.AddFigure(pawnD);

            //var position = new Position(1, 1);
            //var to = player.Move("bdl").To;

            //Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheCdlCommand()
        {
            //var player = new PawnPlayer("Serafim");
            //IFigure pawnA = new PawnA().CreateFigure();
            //IFigure pawnB = new PawnB().CreateFigure();
            //IFigure pawnC = new PawnC().CreateFigure();
            //IFigure pawnD = new PawnD().CreateFigure();
            //player.AddFigure(pawnA);
            //player.AddFigure(pawnB);
            //player.AddFigure(pawnC);
            //player.AddFigure(pawnD);

            //var position = new Position(1, 3);
            //var to = player.Move("cdl").To;

            //Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheDdlCommand()
        {
        //    var player = new PawnPlayer("Serafim");
        //    IFigure pawnA = new PawnA().CreateFigure();
        //    IFigure pawnB = new PawnB().CreateFigure();
        //    IFigure pawnC = new PawnC().CreateFigure();
        //    IFigure pawnD = new PawnD().CreateFigure();
        //    player.AddFigure(pawnA);
        //    player.AddFigure(pawnB);
        //    player.AddFigure(pawnC);
        //    player.AddFigure(pawnD);

        //    var position = new Position(1, 5);
        //    var to = player.Move("ddl").To;

        //    Assert.AreEqual(to, position);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheMoveMethodReturnsCorrectlyTheOldPosition()
        {
            //var player = new PawnPlayer("Serafim");
            //IFigure pawnA = new PawnA().CreateFigure();
            //IFigure pawnB = new PawnB().CreateFigure();
            //IFigure pawnC = new PawnC().CreateFigure();
            //IFigure pawnD = new PawnD().CreateFigure();
            //player.AddFigure(pawnA);
            //player.AddFigure(pawnB);
            //player.AddFigure(pawnC);
            //player.AddFigure(pawnD);
            //var position = new Position(0, 0);
            //var to = player.Move("adl").From;

            //Assert.AreEqual(to, position);
        }
    }
}
