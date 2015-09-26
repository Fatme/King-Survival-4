using KingSurvival.Board;
using KingSurvival.Board.Contracts;
using KingSurvival.FigureFactory;

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

            var king = new KingFigureFactory().CreateFigure(FigureSign.K);
            IBoard board = new Board();
            board.AddFigure(king, new Position(7, 3));

            var kingAdrian = new King(FigureSign.K);

            Assert.AreEqual(king.Sign, kingAdrian.Sign);
        }


    }
}
