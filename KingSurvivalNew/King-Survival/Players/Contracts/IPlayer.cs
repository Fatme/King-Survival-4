namespace KingSurvival.Players.Contracts
{
    using System.Collections.Generic;

    using KingSurvival.Common;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Figures.Contracts;
    public interface IPlayer
    {
        string Name { get; }

        void AddFigure(IFigure figure);

        IList<IFigure> Figures { get; }

        //TODO:Maybe move this method to IMovable interface
        Move Move(string command,IBoard board);
    }
}

