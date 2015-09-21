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
        [ExpectedException(typeof(NullReferenceException))]
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
    }
}
