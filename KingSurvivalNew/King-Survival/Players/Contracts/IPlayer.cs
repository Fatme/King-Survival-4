namespace KingSurvival.Players.Contracts
{
    using System.Collections.Generic;

    using KingSurvival.Common;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common.Contracts;
    public interface IPlayer
    {
        string Name { get; }

        IDictionary<string, int> MapCommandToDirection { get; }

        void AddFigure(IFigure figure);

        IList<IFigure> Figures { get; }

        //TODO:Maybe move this method to IMovable interface
        Move Move(ICommand command, IBoard board);
    }
}

