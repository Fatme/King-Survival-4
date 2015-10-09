namespace KingSurvival.Engine.Contracts
{
    using KingSurvival.Players.Contracts;

    public interface IKingSurvivalEngine
    {
        IKingSurvivalEngine InitializeGame();

        IKingSurvivalEngine StartGame();
    }
}
