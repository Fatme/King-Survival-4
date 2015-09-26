namespace UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival.Board;
    using KingSurvival.Figures;
    using KingSurvival.Common;
    using KingSurvival.Figures.Contracts;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void CheckIfAFigureIsAddedCorrectlyToTheBoard()
        {
            var board = new Board();
            var position = new Position(1, 1);
            var figureSign = FigureSign.K;
            var figure = new King(figureSign);
            board.AddFigure(figure,position);
        }

        [TestMethod]
        public void CheckIfGetFigureAtPositionReturnsTheCorrectFigure()
        {
            var board = new Board();
            var position = new Position(1, 1);
            var position2 = new Position(2, 2);
            var figureSign = FigureSign.K;
            var figure = new King(figureSign);

            board.AddFigure(figure,position);

            Assert.AreEqual(figure, board.GetFigureAtPosition(position));
            Assert.AreNotEqual(figure, board.GetFigureAtPosition(position2));
        }

        [TestMethod]
        public void CheckIfRemoveFigureRemovesTheFigure()
        {
            var board = new Board();
            var position = new Position(1, 1);
            var figureSign = FigureSign.K;
            var figure = new King(figureSign);

            board.AddFigure(figure,position);
            board.RemoveFigure(figure,position);

            Assert.AreNotEqual(figure, board.GetFigureAtPosition(position));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheAddFigureMethodThrowsCorrectlyNullReferenceExeption()
        {
            var board = new Board();
            var position = new Position(-1, -1);
            IFigure figure = new King(FigureSign.K);
            board.AddFigure(figure,position);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheAddFigureMethodThrowsCorrectlyIndexOutOfRangeException()
        {
            var board = new Board();
            var position = new Position(9, 9);

            var figureSign = FigureSign.K;
            var figure = new King(figureSign);

            board.AddFigure(figure,position);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckIfTheRemoveFigureMethodThrowsCorrectlyNullReferenceExeption()
        {
            var board = new Board();
            var position = new Position(1, 1);
            IFigure figure = null;

            board.RemoveFigure(figure,position);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheRemoveFigureMethodThrowsCorrectlyIndexOutOfRangeException()
        {
            var board = new Board();
            var position = new Position(9, 9);

            var figureSign = FigureSign.K;
            var figure = new King(figureSign);

            board.RemoveFigure(figure,position);
        }
    }
}
