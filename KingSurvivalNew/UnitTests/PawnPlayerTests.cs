using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival.Players;
using KingSurvival.Figures;
using KingSurvival.Common;

namespace UnitTests
{
    [TestClass]
    public class PawnPlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfTheMoveMethodThrowsCorrectlyWhenTheCommandIsNotExactlyThreeSymbols()
        {
            var player = new PawnPlayer("Serafim");

            player.Move("aaaa");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckIfTheMoveMethodThrowsCorrectlyIfTheCommandIsThreeSymbolsLongButStillNotCorrect()
        {
            var player = new PawnPlayer("Serafim");
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            player.AddFigure(pawns[0]);
            player.AddFigure(pawns[1]);
            player.AddFigure(pawns[2]);
            player.AddFigure(pawns[3]);

            player.Move("aaa");
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheAdrCommand()
        {
            var player = new PawnPlayer("Serafim");
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            player.AddFigure(pawns[0]);
            player.AddFigure(pawns[1]);
            player.AddFigure(pawns[2]);
            player.AddFigure(pawns[3]);

            var position = new Position(1, 1);
            var to = player.Move("adr").To;

            Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheBdrCommand()
        {
            var player = new PawnPlayer("Serafim");
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            player.AddFigure(pawns[0]);
            player.AddFigure(pawns[1]);
            player.AddFigure(pawns[2]);
            player.AddFigure(pawns[3]);

            var position = new Position(1, 3);
            var to = player.Move("bdr").To;

            Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheCdrCommand()
        {
            var player = new PawnPlayer("Serafim");
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            player.AddFigure(pawns[0]);
            player.AddFigure(pawns[1]);
            player.AddFigure(pawns[2]);
            player.AddFigure(pawns[3]);

            var position = new Position(1, 5);
            var to = player.Move("cdr").To;

            Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheDdrCommand()
        {
            var player = new PawnPlayer("Serafim");
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            player.AddFigure(pawns[0]);
            player.AddFigure(pawns[1]);
            player.AddFigure(pawns[2]);
            player.AddFigure(pawns[3]);

            var position = new Position(1, 7);
            var to = player.Move("ddr").To;

            Assert.AreEqual(to, position);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheAdlCommand()
        {
            var player = new PawnPlayer("Serafim");
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            player.AddFigure(pawns[0]);
            player.AddFigure(pawns[1]);
            player.AddFigure(pawns[2]);
            player.AddFigure(pawns[3]);

            player.Move("adl");
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheBdlCommand()
        {
            var player = new PawnPlayer("Serafim");
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            player.AddFigure(pawns[0]);
            player.AddFigure(pawns[1]);
            player.AddFigure(pawns[2]);
            player.AddFigure(pawns[3]);

            var position = new Position(1, 1);
            var to = player.Move("bdl").To;

            Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheCdlCommand()
        {
            var player = new PawnPlayer("Serafim");
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            player.AddFigure(pawns[0]);
            player.AddFigure(pawns[1]);
            player.AddFigure(pawns[2]);
            player.AddFigure(pawns[3]);

            var position = new Position(1, 3);
            var to = player.Move("cdl").To;

            Assert.AreEqual(to, position);
        }

        [TestMethod]
        public void CheckIfTheMoveMethodSetNewPositionsCorrectlywithTheDdlCommand()
        {
            var player = new PawnPlayer("Serafim");
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            player.AddFigure(pawns[0]);
            player.AddFigure(pawns[1]);
            player.AddFigure(pawns[2]);
            player.AddFigure(pawns[3]);

            var position = new Position(1, 5);
            var to = player.Move("ddl").To;

            Assert.AreEqual(to, position);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckIfTheMoveMethodReturnsCorrectlyTheOldPosition()
        {
            var player = new PawnPlayer("Serafim");
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            player.AddFigure(pawns[0]);
            player.AddFigure(pawns[1]);
            player.AddFigure(pawns[2]);
            player.AddFigure(pawns[3]);

            var position = new Position(0, 0);
            var to = player.Move("adl").From;

            Assert.AreEqual(to, position);
        }
    }
}
