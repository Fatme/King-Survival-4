using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Common;
using KingSurvival.FigureFactory.Contracts;
using KingSurvival.Figures;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.FigureFactory
{
    public class PawnFigureFactory : IFigureFactory
    {
        public IFigure CreateFigure(FigureSign sign)
        {
            IFigure pawn = new Pawn(sign);
            return pawn;
        }

    }
}
