namespace KingSurvival.Players.Contracts
{
    using System.Collections.Generic;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;

    public interface IPlayer
    {
        string Name { get; }

        void AddFigure(IFigure figure);

        IList<IFigure> Figures { get; }

        Move Move(string command);
    }
}

