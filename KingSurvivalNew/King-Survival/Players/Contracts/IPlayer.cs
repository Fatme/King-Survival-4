namespace KingSurvival.Players.Contracts
{
    using System.Collections.Generic;

    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Common.Contracts;
   
    using KingSurvival.Figures.Contracts;

    public interface IPlayer
    {
        string Name { get; }

        int MovesCount { get; set; }

        IList<IFigure> Figures { get; }

        void AddFigure(IFigure figure);

        void ExecuteCommand(ICommandContext context, string commandName);
    }
}