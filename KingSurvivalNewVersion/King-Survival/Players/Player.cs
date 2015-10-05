using System;
using KingSurvival.Commands;
using KingSurvival.Commands.Contracts;

namespace KingSurvival.Players
{
    using System.Collections.Generic;

    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common.Contracts;

    public abstract class Player : IPlayer
    {


        private IList<IFigure> figures;

        public string Name { get; private set; }

        public IList<IFigure> Figures
        {
            get { return this.figures; }
        }

        public Player(string name)
        {
            this.Name = name;
            this.figures = new List<IFigure>();
        }

        public void AddFigure(IFigure figure)
        {
            this.figures.Add(figure);
        }

        public  void ExecuteCommand(ICommandContext context)
        {
            //TODO:THis should not be here
            context.Provier.PrintPlayerNameForNextMove(context.Player.Name);
            var commandFactory = new CommandFactory(context);
            var commandName = context.Provier.GetCommandName;

            if (this.Commands.Contains(commandName))
            {
                ICommand command = commandFactory.CreatePlayerCommand(commandName);
                command.Execute();
            }
            else
            {
                throw new ArgumentException(string.Format("Tnvalid comand for this player. The possible commands are {0} ",string.Join(",",this.Commands)));
            }

        }

        public abstract List<string> Commands { get; }

    }
}
