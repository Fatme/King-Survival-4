namespace KingSurvival.Players
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.Commands.CommandFactory;
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Players.Contracts;

    public abstract class Player : IPlayer
    {
        private IList<IFigure> figures;

        protected Player(string name)
        {
            this.Name = name;
            this.figures = new List<IFigure>();
            this.MovesCount = 0;
        }

        public string Name { get; private set; }

        public int MovesCount { get; set; }

        public IList<IFigure> Figures
        {
            get { return this.figures; }
        }

        public abstract List<string> Commands { get; }

        public void AddFigure(IFigure figure)
        {
            this.figures.Add(figure);
        }

        public virtual void ExecuteCommand(ICommandContext context, string commandName)
        {
            var commandFactory = new CommandFactory();

            if (this.Commands.Contains(commandName))
            {
                ICommand command = commandFactory.CreatePlayerCommand(commandName);
                command.Execute(context);
            }
            else
            {
                throw new ArgumentException(string.Format("Tnvalid comand for this player. The possible commands are {0} ", string.Join(",", this.Commands)));
            }
        }
    }
}
