namespace KingSurvival.Commands.Contracts
{
    using KingSurvival.Board;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Players.Contracts;

    public interface ICommandContext
    {
        BoardMemory Memory { get; set; }

        IBoard Board { get; set; }

        IPlayer Player { get; set; }
    }
}
