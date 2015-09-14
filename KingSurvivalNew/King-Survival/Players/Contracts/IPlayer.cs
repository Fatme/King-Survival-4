using System.Collections;
using System.Collections.Generic;
using KingSurvival.Figures.Contracts;

namespace KingSurvival.Players.Contracts
{
    using KingSurvival.Common;

    public interface IPlayer
    {
        ChessColor Color { get; }

        string Name { get; }

        void AddFigure(IFigure figure);

        IList<IFigure> Figures { get; }
    }
}

