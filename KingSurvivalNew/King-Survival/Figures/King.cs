﻿namespace KingSurvival.Figures
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;


    public class King : Figure, IFigure
    {
        public King(ChessColor color,Position position):base(color,position)
        {
        }

    }
}