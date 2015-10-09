using System;
using System.Collections.Generic;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.Figures
{
    public class PawnAFigure : Figure, IFigure
    {
        protected override string ProvideShape()
        {
            return "A";
        }

        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "adr", "adl" };
            }
        }
    }
}
