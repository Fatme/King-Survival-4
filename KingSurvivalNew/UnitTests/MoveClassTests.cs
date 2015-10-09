namespace UnitTests
{
    using KingSurvival.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MoveClassTests
    {
        [TestMethod]
        public void CheckIfMoveConstructorSetsFromRowCorrectly()
        {
            Position positionFrom = new Position(1, 3);
            Position positionTo = new Position(2, 4);
            Move move = new Move(positionFrom, positionTo);
            int expectedPositionRow = 1;
            Assert.AreEqual(positionFrom.Row, expectedPositionRow);
        }

        [TestMethod]
        public void CheckIfMoveConstructorSetsFromColCorrectly()
        {
            Position positionFrom = new Position(1, 3);
            Position positionTo = new Position(2, 4);
            Move move = new Move(positionFrom, positionTo);
            int expectedPositionRow = 3;
            Assert.AreEqual(positionFrom.Col, expectedPositionRow);
        }

        [TestMethod]
        public void CheckIfMoveConstructorSetsToColCorrectly()
        {
            Position positionFrom = new Position(1, 3);
            Position positionTo = new Position(2, 4);
            Move move = new Move(positionFrom, positionTo);
            int expectedPositionRow = 4;
            Assert.AreEqual(positionTo.Col, expectedPositionRow);
        }

        [TestMethod]
        public void CheckIfMoveConstructorSetsToRowCorrectly()
        {
            Position positionFrom = new Position(1, 3);
            Position positionTo = new Position(2, 4);
            Move move = new Move(positionFrom, positionTo);
            int expectedPositionRow = 2;
            Assert.AreEqual(positionTo.Row, expectedPositionRow);
        }
    }
}
