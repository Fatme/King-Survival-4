﻿namespace UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival.Common;

    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheCheckIfValidMethodThrowsCorrectlyIndexOutOfRangeException()
        {
            var position = new Position(10, 11);
            Position.CheckIfValid(position, "aaa");
        }
    }
}
