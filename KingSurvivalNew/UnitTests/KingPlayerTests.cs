using System;
using System.Collections.Generic;
using KingSurvival.Board;
using KingSurvival.Board.Contracts;
using KingSurvival.Commands;
using KingSurvival.Commands.CommandFactory;
using KingSurvival.Commands.Contracts;
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
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfAnExceptionIsThrownWhenTheCommandIsNotExactlyThreeSymbols()
        {
            var player = new KingPlayer("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory();
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext, "aaaa");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfAnExceptionIsThrownWhenTheCommandIsThreeSymbolsLongButStillNotCorrect()
        {
            var player = new KingPlayer("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory();
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext, "aaa");
        }

        [TestMethod]
        public void CheckIfTheKurDirectionIsCorrectlyChanged()
        {
            var player = new KingPlayer("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"kur");

            var actualPosition = board.GetFigurePosition(king);
            var expectedPosition = new Position(6, 4);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheKdrThrowsWhenPositionIsNotValid()
        {
            var player = new KingPlayer("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext, "kdr");

           
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheKdlDirectionThrowsWhenThePositionIsNotValid()
        {
            var player = new KingPlayer("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext, "kdl");
        }

        [TestMethod]
        public void CheckIfTheKulDirectionIsCorrectlyChanged()
        {
            var player = new KingPlayer("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory();
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"kul");

            var actualPosition = board.GetFigurePosition(king);
            var expectedPosition = new Position(6, 2);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfAnExceptionIsThrownWhenTheCommandIsFromPawnPlayer()
        {
            var player = new KingPlayer("Serafim");

            var king = new Figure(FigureSign.K);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory();
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext, "adr");
        }
    }
}
