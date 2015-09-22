using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival.Players;
using KingSurvival.Figures;
using KingSurvival.Common;

namespace UnitTests
{
    [TestClass]
    public class KingPlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfTheMoveMethodThrowsCorrectlyWhenTheCommandIsNotExactlyThreeSymbols()
        {
            var player = new KingPlayer("Serafim");

            player.Move("aaaa");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfTheMoveMethodThrowsCorrectlyIfTheCommandIsThreeSymbolsLongButStillNotCorrect()
        {
            var player = new KingPlayer("Serafim");
            var factory = new FiguresFactory();
            var king = factory.CreateKing();
            player.AddFigure(king);

            player.Move("aaa");
        }

        //TODO: Set a test for the king position

        [TestMethod]
        public void CheckIfTheMoveMethodChangeTheKurDirectionCorrectly()
        {
            var player = new KingPlayer("Serafim");
            var factory = new FiguresFactory();
            var king = factory.CreateKing();

            player.AddFigure(king);
            var to = player.Move("kur").To;
            var position = new Position(6, 4);

            Assert.AreEqual(to, position);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheMoveMethodChangeTheKdrDirectionCorrectly()
        {
            var player = new KingPlayer("Serafim");
            var factory = new FiguresFactory();
            var king = factory.CreateKing();

            player.AddFigure(king);
            player.Move("kdr");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheMoveMethodChangeTheKdlDirectionCorrectly()
        {
            var player = new KingPlayer("Serafim");
            var factory = new FiguresFactory();
            var king = factory.CreateKing();

            player.AddFigure(king);
            player.Move("kdl");
        }

        [TestMethod]
        public void CheckIfTheMoveMethodChangeTheKulDirectionCorrectly()
        {
            var player = new KingPlayer("Serafim");
            var factory = new FiguresFactory();
            var king = factory.CreateKing();

            player.AddFigure(king);
            var to = player.Move("kul").To;
            var position = new Position(6, 2);

            Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodReturnsTheOldPositionCorrectly()
        {
            var player = new KingPlayer("Serafim");
            var factory = new FiguresFactory();
            var king = factory.CreateKing();

            player.AddFigure(king);
            var from = player.Move("kul").From;
            var position = new Position(7, 3);

            Assert.AreEqual(from, position);
        }
    }
}
