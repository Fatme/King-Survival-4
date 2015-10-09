namespace UnitTests
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.Board;
    using KingSurvival.Common;
    using KingSurvival.Figures;
    using KingSurvival.Players;
    using KingSurvival.Players.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckIfTheCheckIfObjectIsNullMethodThrowsCorrectlyNullReferenceException()
        {
            object obj = null;

            Validator.CheckIfObjectIsNull(obj, "aaa");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CheckIfTheValidateGameInitializationMethodThrowsCorrectlyInvalidOperationExceptionWhenPlayersareIncorrect()
        {
            var adrian = new Player("Adrian");
            var martin = new Player("Martin");
            var blajev = new Player("Blajev");

            var board = new Board();

            var list = new List<IPlayer>();

            list.Add(adrian);
            list.Add(martin);
            list.Add(blajev);

            Validator.ValidateGameInitialization(list, board);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CheckIfTheValidateGameInitializationMethodThrowsCorrectlyInvalidOperationExceptionWhenColsOrRowsAreIncorrect()
        {
            var adrian = new Player("Adrian");
            var martin = new Player("Martin");

            var board = new Board(10, 10);

            var list = new List<IPlayer>();

            list.Add(adrian);
            list.Add(martin);

            Validator.ValidateGameInitialization(list, board);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CheckIfTheValidateGameInitializationMethodThrowsCorrectlyInvalidOperationExceptionWhenPlayersAndBoardAreIncorrect()
        {
            var adrian = new Player("Adrian");
            var martin = new Player("Martin");
            var blajev = new Player("Blajev");

            var board = new Board(10, 10);

            var list = new List<IPlayer>();

            list.Add(adrian);
            list.Add(martin);
            list.Add(blajev);

            Validator.ValidateGameInitialization(list, board);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfCheckFigureOnTheWayWorksProperlyWhenFigureIsOnTheWay()
        {
            var board = new Board();
            var figure = new KingFigure();
            var position = new Position(1, 1);
            board.AddFigure(figure, position);
            Validator.CheckIfFigureOnTheWay(position, board, "Figure on the way");
        }

        [TestMethod]
        public void CheckIfCheckFigureOnTheWayWorksProperlyWhenNoFigureOnTheWay()
        {
            var board = new Board();
            var figure = new KingFigure();
            var position = new Position(1, 1);
            board.AddFigure(figure, position);
            var expectedPosition = new Position(2, 2);
            Validator.CheckIfFigureOnTheWay(expectedPosition, board, "No figure on the way");
        }
    }
}
