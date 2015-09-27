using System;
using System.Collections.Generic;
using KingSurvival.Board;
using KingSurvival.Board.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival.Players;
using KingSurvival.Figures;
using KingSurvival.Common;
using KingSurvival.Engine;
using KingSurvival.FigureFactory;
using KingSurvival.Figures.Contracts;
using KingSurvival.Players.Contracts;

namespace UnitTests
{
    [TestClass]
    public class KingPlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfTheMoveMethodThrowsCorrectlyWhenTheCommandIsNotExactlyThreeSymbols()
        {
            var player = new KingPlayer("Serafim");
            IBoard board = new Board();
            IFigure king = new KingFigureFactory().CreateFigure(FigureSign.K);
            board.AddFigure(king, new Position(Constants.initialKingRow, Constants.initialKingColumn));
            player.Move("aaaa", board);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfTheMoveMethodThrowsCorrectlyIfTheCommandIsThreeSymbolsLongButStillNotCorrect()
        {
            var player = new KingPlayer("Serafim");
            IBoard board = new Board();
            IFigure king = new KingFigureFactory().CreateFigure(FigureSign.K);
            board.AddFigure(king, new Position(Constants.initialKingRow, Constants.initialKingColumn));
            player.Move("aaa", board);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodChangeTheKurDirectionCorrectly()
        {
            List<IPlayer> players = new List<IPlayer>();
            players.Add(new KingPlayer("king"));
            players.Add(new PawnPlayer("pawn"));
            IBoard board = new Board();
            var firstPlayer = players[0];
            IFigure king = new KingFigureFactory().CreateFigure(FigureSign.K);
            firstPlayer.AddFigure(king);
            board.AddFigure(king, new Position(Constants.initialKingRow, Constants.initialKingColumn));

            var secondPlayer = players[1];
            IFigure pawnA = new PawnFigureFactory().CreateFigure(FigureSign.A);
            IFigure pawnB = new PawnFigureFactory().CreateFigure(FigureSign.B);
            IFigure pawnC = new PawnFigureFactory().CreateFigure(FigureSign.C);
            IFigure pawnD = new PawnFigureFactory().CreateFigure(FigureSign.D);
            secondPlayer.AddFigure(pawnA);
            secondPlayer.AddFigure(pawnB);
            secondPlayer.AddFigure(pawnC);
            secondPlayer.AddFigure(pawnD);
            board.AddFigure(pawnA, new Position(Constants.pawnAInitialRow, Constants.pawnAInitialCol));
            board.AddFigure(pawnB, new Position(Constants.pawnBInitialRow, Constants.pawnBInitialCol));
            board.AddFigure(pawnC, new Position(Constants.pawnCInitialRow, Constants.pawnCInitialCol));
            board.AddFigure(pawnD, new Position(Constants.pawnDInitialRow, Constants.pawnDInitialCol));
            Move move = firstPlayer.Move("kur", board);
            var expectedRow = 6;
            Assert.AreEqual(move.To.Row, expectedRow);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheMoveMethodChangeTheKdrDirectionCorrectly()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheMoveMethodChangeTheKdlDirectionCorrectly()
        {
            //var player = new KingPlayer("Serafim");
            //var king = new KingFigureFactory().CreateFigure();

            //player.AddFigure(king);
            //player.Move("kdl");
        }

        [TestMethod]
        public void CheckIfTheMoveMethodChangeTheKulDirectionCorrectly()
        {
            //var player = new KingPlayer("Serafim");
            //var king = new KingFigureFactory().CreateFigure();

            //player.AddFigure(king);
            //var to = player.Move("kul").To;
            //var position = new Position(6, 2);

            //Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodReturnsTheOldPositionCorrectly()
        {
            //var player = new KingPlayer("Serafim");
            //var king = new KingFigureFactory().CreateFigure();

            //player.AddFigure(king);
            //var from = player.Move("kul").From;
            //var position = new Position(7, 3);

            //Assert.AreEqual(from, position);
        }
    }
}
