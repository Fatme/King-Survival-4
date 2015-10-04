using System;
using System.Collections.Generic;
using KingSurvival.Board;
using KingSurvival.Board.Contracts;
using KingSurvival.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival.Players;
using KingSurvival.Figures;
using KingSurvival.Common;
using KingSurvival.Engine;

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
            var player = new Player("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("aaaa");
            playerCommand.Execute(player.Figures);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfTheMoveMethodThrowsCorrectlyIfTheCommandIsThreeSymbolsLongButStillNotCorrect()
        {
            var player = new Player("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("aaa");
            playerCommand.Execute(player.Figures);
        }

        [TestMethod]
        public void CheckIfTheKurDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("kur");
            playerCommand.Execute(player.Figures);

            var actualPosition = board.GetFigurePosition(king);
            var expectedPosition = new Position(6, 4);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheKdrDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("kdr");
            playerCommand.Execute(player.Figures);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheKdlDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("kdl");
            playerCommand.Execute(player.Figures);
        }

        [TestMethod]
        public void CheckIfTheKulDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("kul");
            playerCommand.Execute(player.Figures);

            var actualPosition = board.GetFigurePosition(king);
            var expectedPosition = new Position(6, 2);
               
            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }
    }
}
