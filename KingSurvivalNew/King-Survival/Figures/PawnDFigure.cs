using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.Figures
{
    public class PawnDFigure : Figure, IFigure
    {
        protected override string ProvideShape()
        {
            return "D";
        }
        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "ddr", "ddl" };
            }
        }
    }
}
