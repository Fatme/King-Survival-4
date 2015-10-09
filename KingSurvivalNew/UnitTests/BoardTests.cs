namespace UnitTests
{
    using System;

    using KingSurvival.Board;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Figures;
    using KingSurvival.Figures.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void CheckIfAFigureIsAddedCorrectlyToTheBoard()
        {
            var board = new Board();
            var position = new Position(1, 1);
            var figure = new KingFigure();
            board.AddFigure(figure, position);
            Assert.AreEqual(figure, board.GetFigureAtPosition(position));
        }

        [TestMethod]
        public void CheckIfGetFigureAtPositionReturnsTheCorrectFigure()
        {
            var board = new Board();
            var position = new Position(1, 1);
            var figure = new KingFigure();
            board.AddFigure(figure, position);

            Assert.AreEqual(figure, board.GetFigureAtPosition(position));
        }

        [TestMethod]
        public void CheckIfRemoveFigureRemovesTheFigure()
        {
            var board = new Board();
            var position = new Position(1, 1);
            var figure = new KingFigure();
            board.AddFigure(figure, position);
            board.RemoveFigure(figure, position);

            Assert.AreNotEqual(figure, board.GetFigureAtPosition(position));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheRemoveFigureMethodThrowsCorrectlyIndexOutOfRangeException()
        {
            var board = new Board();
            var position = new Position(9, 9);
            var figure = new KingFigure();

            board.RemoveFigure(figure, position);
        }

        [TestMethod]
        public void CheckIfConstructorSetNumberOfColumnsCorrectly()
        {
            IBoard board = new Board(8, 8);
            int expectedNumberOfColumns = 8;
            Assert.AreEqual(board.NumberOfColumns, expectedNumberOfColumns);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckIfAddNullFigureThrowsException()
        {
            var board = new Board();
            var position = new Position(6, 6);
            IFigure figure = null;
            board.AddFigure(figure, position);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckfAddFigureMethodThrowsWhenPositionIsNotValid()
        {
            var board = new Board();
            var position = new Position(9, 9);
            IFigure king = new KingFigure();

            board.AddFigure(king, position);
        }

        [TestMethod]
        public void CheckIfAddFigureWorksCorrectlyWithCorrectFigureAndCorrectPosition()
        {
            var board = new Board();
            var position = new Position(3, 7);
            IFigure king = new KingFigure();

            board.AddFigure(king, position);
            Assert.AreSame(king, board.GetFigureAtPosition(position));
        }

        [TestMethod]
        public void CheckIfGetFigureAtPositionWorkCorrectly()
        {
            var board = new Board();
            var figure = new KingFigure();
            board.AddFigure(figure, new Position(1, 1));
            var realFigure = board.GetFigureAtPosition(new Position(1, 1));

            Assert.AreEqual(figure, realFigure);
        }

        [TestMethod]
        public void CheckIfGetFigurePositionRowWorksCorrectlyWhenCorrectInput()
        {
            var board = new Board();
            var figure = new KingFigure();
            board.AddFigure(figure, new Position(1, 1));
            var actualPosition = board.GetFigurePosition(figure);
            var expectedPosition = new Position(1, 1);
            Assert.AreEqual(expectedPosition.Row, actualPosition.Row);
        }

        [TestMethod]
        public void CheckIfSaveMementoSavesBoardCorrectly()
        {
            var board = new Board();
            var figure = new KingFigure();
            board.AddFigure(figure, new Position(1, 1));
            var actual = board.SaveMemento();
            Assert.AreEqual(actual.Board.GetLength(1), board.NumberOfColumns);
        }

        [TestMethod]
        public void CheckIfRestoreMementoRestoresBoardCorrectly()
        {
            var board = new Board();
            var figure = new KingFigure();
            board.AddFigure(figure, new Position(1, 1));
            var memento = board.SaveMemento();
            board.RestoreMemento(memento);
            Assert.AreEqual(memento.Board.GetLength(1), board.NumberOfColumns);
        }
    }
}
