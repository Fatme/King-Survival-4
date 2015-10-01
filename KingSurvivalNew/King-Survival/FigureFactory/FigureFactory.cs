﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Figures;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.FigureFactory.Contracts
{
    public class FigureFactory : IFigureFactory
    {
        public IFigure CreateFigure()
        {
            return new Figure();
        }
    }
}
