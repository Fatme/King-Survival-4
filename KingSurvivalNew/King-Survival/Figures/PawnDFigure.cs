﻿namespace KingSurvival.Figures
{
    using System.Collections.Generic;

    using KingSurvival.Figures.Contracts;

    public class PawnDFigure : Figure, IFigure
    {
        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "ddr", "ddl" };
            }
        }

        public override string DisplayName
        {
            get
            {
                return "D";
            }
        }
    }
}
