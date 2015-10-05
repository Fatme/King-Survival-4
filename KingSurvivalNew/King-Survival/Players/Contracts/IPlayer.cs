using KingSurvival.Commands.Contracts;

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

        void AddFigure(IFigure figure);

        IList<IFigure> Figures { get; }

        void ExecuteCommand(ICommandContext context,string commandName);
    }
}

