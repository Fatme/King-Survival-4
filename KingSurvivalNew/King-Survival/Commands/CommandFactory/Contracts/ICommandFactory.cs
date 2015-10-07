namespace KingSurvival.Commands.CommandFactory.Contracts
{
    using KingSurvival.Commands.Contracts;

    public interface ICommandFactory
    {
        ICommand CreatePlayerCommand(string commandName);
    }
}
