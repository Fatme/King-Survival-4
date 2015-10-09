namespace KingSurvival.Commands.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        void Execute(ICommandContext cmdContext);
    }
}
