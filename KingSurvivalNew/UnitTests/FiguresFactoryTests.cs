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
        public void CheckIfCreateFigureKingWorksCorrectly()
        {

            var king = new KingFigureFactory().CreateFigure(FigureSign.K);
            var kingAdrian = new King();
            Assert.AreEqual(king.Sign, kingAdrian.Sign);
        }


    }
}
