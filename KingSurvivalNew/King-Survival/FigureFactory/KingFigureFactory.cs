using KingSurvival.Common;
using KingSurvival.Figures.Contracts;
using System;
using System.Collections.Generic;
using KingSurvival.FigureFactory.Contracts;
using KingSurvival.Figures;


namespace KingSurvival.FigureFactory
{
    public class KingFigureFactory : IFigureFactory
    {
        public IFigure CreateFigure(FigureSign sign)
        {
            IFigure king = new King(sign);
            return king;
        }

      
    }
}
