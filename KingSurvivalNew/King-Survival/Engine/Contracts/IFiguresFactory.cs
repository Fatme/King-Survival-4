using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Figures.Contracts
{
    interface IFiguresFactory
    {

        IFigure CreateKing();

        IList<IFigure> CreatePawns();
    }
}
