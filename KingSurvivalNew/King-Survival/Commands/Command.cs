namespace KingSurvival.Commands
{
    using KingSurvival.Commands.Contracts;

    public abstract class Command : ICommand
    {
        public abstract string Name { get; }

        public abstract void Execute(ICommandContext context, string commandName);
    }
}
