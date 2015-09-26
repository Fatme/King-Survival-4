using System.Collections.Generic;
using KingSurvival.Board.Contracts;
using KingSurvival.Players.Contracts;

namespace KingSurvival.Common.Contracts
{
    public interface IWinningConditions
    {
        bool KingWon(IList<IPlayer> players,IBoard board );

        bool KingLost(IList<IPlayer> players, IBoard board);
    }
}
