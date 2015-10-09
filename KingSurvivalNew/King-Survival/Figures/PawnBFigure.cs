﻿namespace KingSurvival.Figures
{
    using System.Collections.Generic;
    using KingSurvival.Figures.Contracts;

    public class PawnBFigure : Figure, IFigure
    {
        protected override List<string> ValidCommands
        {
            get
            {
                return new List<string>() { "bdr", "bdl" };
            }
        }

        protected override string ProvideShape()
        {
            return "B";
        }
    }
}