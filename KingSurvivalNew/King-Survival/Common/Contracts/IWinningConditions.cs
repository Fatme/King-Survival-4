namespace KingSurvival.Commands.Contracts
{
    using System.Collections.Generic;

    using KingSurvival.Board.Contracts;
    using KingSurvival.Players.Contracts;

    public interface IWinningConditions
    {
        bool KingWon(IList<IPlayer> players,IBoard board );

        bool KingLost(IList<IPlayer> players, IBoard board);
    }
}
