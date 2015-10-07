namespace KingSurvival.Commands.Contracts
{
    using KingSurvival.Board;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Players.Contracts;

    public interface ICommandContext
    {
        BoardMemory Memory { get; }

        IBoard Board { get; }

        IPlayer Player { get; set; }
    }
}
