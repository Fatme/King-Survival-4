﻿using KingSurvival.Figures;

namespace UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival.Common;
    using System.Collections.Generic;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Players;
    using KingSurvival.Board;

    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckIfTheCheckIfObjectIsNullMethodThrowsCorrectlyNullReferenceException()
        {
            var obj = new Object();
            obj = null;

            Validator.CheckIfObjectIsNull(obj, "aaa");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CheckIfTheValidateGameInitializationMethodThrowsCorrectlyInvalidOperationExceptionWhenPlayersareIncorrect()
        {
            var adrian = new KingPlayer("Adrian");
            var martin = new KingPlayer("Martin");
            var blajev = new KingPlayer("Blajev");

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
            var adrian = new KingPlayer("Adrian");
            var martin = new KingPlayer("Martin");

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
            var adrian = new KingPlayer("Adrian");
            var martin = new KingPlayer("Martin");
            var blajev = new KingPlayer("Blajev");

            var board = new Board(10,10);

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
            var board=new Board();
            var figure = new Figure();
            var position=new Position(1,1);
            board.AddFigure(figure,position);
            Validator.CheckIfFigureOnTheWay(position,board,"Figure on the way");
        }
        [TestMethod]
        public void CheckIfCheckFigureOnTheWayWorksProperlyWhenNoFigureOnTheWay()
        {
            var board = new Board();
            var figure = new Figure();
            var position = new Position(1, 1);
            board.AddFigure(figure, position);
            var expectedPosition=new Position(2,2);
            Validator.CheckIfFigureOnTheWay(expectedPosition, board, "No figure on the way");
        }

    }
}
