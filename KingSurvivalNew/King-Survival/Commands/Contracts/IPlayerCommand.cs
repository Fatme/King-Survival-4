namespace KingSurvival.Commands.Contracts
{
    public interface IMoveCommand : ICommand
    {
        int Direction { get; }

        int FigureIndex { get; }
    }
}
