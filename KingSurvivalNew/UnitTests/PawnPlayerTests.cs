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
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfAnExceptionIsThrownWhenTheCommandIsNotExactlyThreeSymbols()
        {
            var player = new PawnPlayer("Serafim");

            var king = new Figure(FigureSign.A);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory();
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"aaaa");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfTheMoveMethodThrowsCorrectlyIfTheCommandIsThreeSymbolsLongButStillNotCorrect()
        {
            var player = new PawnPlayer("Serafim");

            var king = new Figure(FigureSign.A);
            player.AddFigure(king);

            var board = new Board();
            var position = new Position(Constants.InitialKingRow, Constants.InitialKingColumn);
            board.AddFigure(king, position);

            var commandFactory = new CommandFactory();
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"aaa");
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheAdrCommand()
        {
            var player = new PawnPlayer("Serafim");

            var pawn = new Figure(FigureSign.A);
            player.AddFigure(pawn);

            var board = new Board();
            var position = new Position(Constants.PawnAInitialRow, Constants.PawnAInitialCol);
            board.AddFigure(pawn, position);

            var commandFactory = new CommandFactory();
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"adr");

            var actualPosition = board.GetFigurePosition(pawn);
            var expectedPosition = new Position(1, 1);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlyWithTheBdrCommand()
        {
            var player = new PawnPlayer("Serafim");

            var pawnA = new Figure(FigureSign.A);
            player.AddFigure(pawnA);

            var pawnB = new Figure(FigureSign.B);
            player.AddFigure(pawnB);

            var board = new Board();
            var position = new Position(Constants.PawnBInitialRow, Constants.PawnBInitialCol);

            board.AddFigure(pawnA, position);
            board.AddFigure(pawnB, position);

            var commandFactory = new CommandFactory();
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            

            player.ExecuteCommand(commandContext,"bdr");

            var actualPosition = board.GetFigurePosition(pawnB);
            var expectedPosition = new Position(1, 3);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheCdrCommand()
        {
            var player = new PawnPlayer("Serafim");

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

            var commandFactory = new CommandFactory();
            
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"cdr");

            var actualPosition = board.GetFigurePosition(pawnC);
            var expectedPosition = new Position(1, 5);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheDdrCommand()
        {
            var player = new PawnPlayer("Serafim");

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

            var commandFactory = new CommandFactory();
            var playerCommand = commandFactory.CreatePlayerCommand("ddr");
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"ddr");

            var actualPosition = board.GetFigurePosition(pawnD);
            var expectedPosition = new Position(1, 7);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheAdlCommand()
        {
            var player = new PawnPlayer("Serafim");

            var pawn = new Figure(FigureSign.A);
            player.AddFigure(pawn);

            var board = new Board();
            var position = new Position(0, 0);
            board.AddFigure(pawn, position);

            var commandFactory = new CommandFactory();
           
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"adl");
            
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheBdlCommand()
        {
            var player = new PawnPlayer("Serafim");

            var pawnA = new Figure(FigureSign.A);
            player.AddFigure(pawnA);

            var pawnB = new Figure(FigureSign.B);
            player.AddFigure(pawnB);

            var board = new Board();
            var position = new Position(Constants.PawnBInitialRow, Constants.PawnBInitialCol);

            board.AddFigure(pawnA, position);
            board.AddFigure(pawnB, position);

            var commandFactory = new CommandFactory();
            
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"bdl");

            var actualPosition = board.GetFigurePosition(pawnB);
            var expectedPosition = new Position(1, 1);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheCdlCommand()
        {
            var player = new PawnPlayer("Serafim");

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

            var commandFactory = new CommandFactory();
          
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"cdl");

            var actualPosition = board.GetFigurePosition(pawnC);
            var expectedPosition = new Position(1, 3);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheDdlCommand()
        {
            var player = new PawnPlayer("Serafim");

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

            var commandFactory = new CommandFactory();
            
            var commandContext = new CommandContext(new BoardMemory(), board, player);
            player.ExecuteCommand(commandContext,"ddl");

            var actualPosition = board.GetFigurePosition(pawnD);
            var expectedPosition = new Position(1, 5);

            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
            Assert.AreEqual(expectedPosition.Col, actualPosition.Col);
        }

    }
}
