using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.Figures
{
    public class PawnCFigure : Figure, IFigure
    {
        protected override string ProvideShape()
        {
            return "C";
        }
        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "cdr", "cdl" };
            }
        }
    }
}
