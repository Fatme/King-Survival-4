﻿namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Common;

    public interface IFigure
    {
        ChessColor Color { get; }

        Position Position { get; set; }
    }
}


