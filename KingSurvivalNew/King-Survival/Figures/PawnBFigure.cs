﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.Figures
{
    public class PawnBFigure : Figure, IFigure
    {
        protected override string ProvideShape()
        {
            return "B";
        }
    }
}
