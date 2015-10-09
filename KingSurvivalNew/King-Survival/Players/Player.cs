namespace KingSurvival.Players
{
    using System.Collections.Generic;

    using KingSurvival.Commands.CommandFactory;
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Players.Contracts;

    public class Player : IPlayer
    {
        private IList<IFigure> figures;

        public Player(string name)
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

        public void AddFigure(IFigure figure)
        {
            this.figures.Add(figure);
        }

        public void ExecuteCommand(ICommandContext context, string commandName)
        {
            var commandFactory = new CommandFactory();
            ICommand command = commandFactory.CreatePlayerCommand(commandName);
            command.Execute(context);
        }
    }
}
