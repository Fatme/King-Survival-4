namespace UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival.Engine;
    using KingSurvival.Figures;
    using KingSurvival.Common;

    [TestClass]
    public class FiguresFactoryTests
    {
        [TestMethod]
        public void CheckIfCreateKingWorksCorrectly()
        {
            var factory = new FiguresFactory();
            var king = factory.CreateKing();
            var position = king.Position;

            var positionAdrian = new Position(7, 3);
            var kingAdrian = new King(FigureSign.K, positionAdrian);

            Assert.AreEqual(king.Position, kingAdrian.Position);
            Assert.AreEqual(king.Sign, kingAdrian.Sign);
        }

        [TestMethod]
        public void CheckIfCreatePawnsWorksCorrectly()
        {
            var factory = new FiguresFactory();
            var pawns = factory.CreatePawns();
            var positionOfTheFirstPawn = new Position(0, 0);
            var positionOfTheSecondPawn = new Position(0, 2);
            var positionOfTheThirdPawn = new Position(0, 4);
            var positionOfTheFourthPawn = new Position(0, 6);

            var signOfTheFirstPawn = FigureSign.A;
            var signOfTheSecondPawn = FigureSign.B;
            var signOfTheThirdPawn = FigureSign.C;
            var signOfTheFourthPawn = FigureSign.D;

            Assert.AreEqual(pawns[0].Position, positionOfTheFirstPawn);
            Assert.AreEqual(pawns[1].Position, positionOfTheSecondPawn);
            Assert.AreEqual(pawns[2].Position, positionOfTheThirdPawn);
            Assert.AreEqual(pawns[3].Position, positionOfTheFourthPawn);

            Assert.AreEqual(pawns[0].Sign, signOfTheFirstPawn);
            Assert.AreEqual(pawns[1].Sign, signOfTheSecondPawn);
            Assert.AreEqual(pawns[2].Sign, signOfTheThirdPawn);
            Assert.AreEqual(pawns[3].Sign, signOfTheFourthPawn);
        }
    }
}
