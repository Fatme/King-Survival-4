namespace UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival.Commands;

    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheCheckIfValidMethodThrowsCorrectlyIndexOutOfRangeException()
        {
            var position = new Position(10, 11);
            Validator.CheckIfPositionValid(position, "aaa");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheCheckIfValidMethodThrowsCorrectlyIndexOutOfRangeException2()
        {
            var position = new Position(0, -1);
            Validator.CheckIfPositionValid(position, "aaa");
        }
    }
}
