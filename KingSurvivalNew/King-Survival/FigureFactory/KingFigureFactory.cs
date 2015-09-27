namespace KingSurvival.FigureFactory
{
    using System;

    using KingSurvival.Common;
    using KingSurvival.Figures.Contracts;
    using System.Collections.Generic;
    using KingSurvival.FigureFactory.Contracts;
    using KingSurvival.Figures;

    public class KingFigureFactory : IFigureFactory
    {
        public IFigure CreateFigure(FigureSign sign = FigureSign.K)
        {
            IFigure king = new King();
            return king;
        }
    }
}
