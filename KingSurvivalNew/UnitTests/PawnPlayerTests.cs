using System;
using System.Collections.Generic;
using KingSurvival.Board;
using KingSurvival.Board.Contracts;
using KingSurvival.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival.Players;
using KingSurvival.Figures;
using KingSurvival.Common;
using KingSurvival.Figures.Contracts;

using KingSurvival.Players.Contracts;

namespace UnitTests
{
    [TestClass]
    public class PawnPlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfAnExceptionIsThrownWhenTheCommandIsNotExactlyThreeSymbols()
        {
            var player = new Player("Serafim");

            var king = new Figure(FigureSign.A);
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
        public void CheckIfAnExceptionIsThrownWhenTheCommandIsThreeSymbolsLongButStillNotCorrect()
        {
            var player = new Player("Serafim");

            var king = new Figure(FigureSign.A);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("bbb");
            playerCommand.Execute(player.Figures);
        }

        [TestMethod]
        public void CheckIfTheAdrDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var pawn = new Figure(FigureSign.A);
            player.AddFigure(pawn);

            var board = new Board();
            var position = new Position(Constants.PawnAInitialRow, Constants.PawnAInitialCol);
            board.AddFigure(pawn, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("adr");
            playerCommand.Execute(player.Figures);

            var actualPosition = board.GetFigurePosition(pawn);
            var expectedPosition = new Position(1, 1);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        public void CheckIfTheBdrDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var pawnA = new Figure(FigureSign.A);
            player.AddFigure(pawnA);

            var pawnB = new Figure(FigureSign.B);
            player.AddFigure(pawnB);

            var board = new Board();
            var position = new Position(Constants.PawnBInitialRow, Constants.PawnBInitialCol);

            board.AddFigure(pawnA, position);
            board.AddFigure(pawnB, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("bdr");
            playerCommand.Execute(player.Figures);

            var actualPosition = board.GetFigurePosition(pawnB);
            var expectedPosition = new Position(1, 3);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        public void CheckIfTheCdrDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var pawnA = new Figure(FigureSign.A);
            player.AddFigure(pawnA);

            var pawnB = new Figure(FigureSign.B);
            player.AddFigure(pawnB);

            var pawnC = new Figure(FigureSign.C);
            player.AddFigure(pawnC);

            var board = new Board();
            var position = new Position(Constants.PawnCInitialRow, Constants.PawnCInitialCol);

            board.AddFigure(pawnA, position);
            board.AddFigure(pawnB, position);
            board.AddFigure(pawnC, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("cdr");
            playerCommand.Execute(player.Figures);

            var actualPosition = board.GetFigurePosition(pawnC);
            var expectedPosition = new Position(1, 5);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        public void CheckIfTheDdrDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var pawnA = new Figure(FigureSign.A);
            player.AddFigure(pawnA);

            var pawnB = new Figure(FigureSign.B);
            player.AddFigure(pawnB);

            var pawnC = new Figure(FigureSign.C);
            player.AddFigure(pawnC);

            var pawnD = new Figure(FigureSign.D);
            player.AddFigure(pawnD);

            var board = new Board();
            var position = new Position(Constants.PawnDInitialRow, Constants.PawnDInitialCol);

            board.AddFigure(pawnA, position);
            board.AddFigure(pawnB, position);
            board.AddFigure(pawnC, position);
            board.AddFigure(pawnD, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("ddr");
            playerCommand.Execute(player.Figures);

            var actualPosition = board.GetFigurePosition(pawnD);
            var expectedPosition = new Position(1, 7);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheAdlDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var pawn = new Figure(FigureSign.A);
            player.AddFigure(pawn);

            var board = new Board();
            var position = new Position(Constants.PawnAInitialRow, Constants.PawnAInitialCol);
            board.AddFigure(pawn, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("adl");
            playerCommand.Execute(player.Figures);
        }

        [TestMethod]
        public void CheckIfTheBdlDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var pawnA = new Figure(FigureSign.A);
            player.AddFigure(pawnA);

            var pawnB = new Figure(FigureSign.B);
            player.AddFigure(pawnB);

            var board = new Board();
            var position = new Position(Constants.PawnBInitialRow, Constants.PawnBInitialCol);

            board.AddFigure(pawnA, position);
            board.AddFigure(pawnB, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("bdl");
            playerCommand.Execute(player.Figures);

            var actualPosition = board.GetFigurePosition(pawnB);
            var expectedPosition = new Position(1, 1);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        public void CheckIfTheCdlDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var pawnA = new Figure(FigureSign.A);
            player.AddFigure(pawnA);

            var pawnB = new Figure(FigureSign.B);
            player.AddFigure(pawnB);

            var pawnC = new Figure(FigureSign.C);
            player.AddFigure(pawnC);

            var board = new Board();
            var position = new Position(Constants.PawnCInitialRow, Constants.PawnCInitialCol);

            board.AddFigure(pawnA, position);
            board.AddFigure(pawnB, position);
            board.AddFigure(pawnC, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("cdl");
            playerCommand.Execute(player.Figures);

            var actualPosition = board.GetFigurePosition(pawnC);
            var expectedPosition = new Position(1, 3);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        public void CheckIfTheDdlDirectionIsCorrectlyChanged()
        {
            var player = new Player("Serafim");

            var pawnA = new Figure(FigureSign.A);
            player.AddFigure(pawnA);

            var pawnB = new Figure(FigureSign.B);
            player.AddFigure(pawnB);

            var pawnC = new Figure(FigureSign.C);
            player.AddFigure(pawnC);

            var pawnD = new Figure(FigureSign.D);
            player.AddFigure(pawnD);

            var board = new Board();
            var position = new Position(Constants.PawnDInitialRow, Constants.PawnDInitialCol);

            board.AddFigure(pawnA, position);
            board.AddFigure(pawnB, position);
            board.AddFigure(pawnC, position);
            board.AddFigure(pawnD, position);

            var commandFactory = new CommandFactory(board);
            var playerCommand = commandFactory.CreatePlayerCommand("ddl");
            playerCommand.Execute(player.Figures);

            var actualPosition = board.GetFigurePosition(pawnD);
            var expectedPosition = new Position(1, 5);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }
    }
}
