namespace KingSurvival.Engine.Contracts
{
    using KingSurvival.Players.Contracts;

    public interface IChessEngine
    {
        IChessEngine InitializeGame();

        IChessEngine StartGame();
    }
}
