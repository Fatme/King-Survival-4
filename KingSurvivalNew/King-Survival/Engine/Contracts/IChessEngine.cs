using KingSurvival.Board.Contracts;

namespace KingSurvival.Engine.Contracts
{
    using System.Collections.Generic;

    using KingSurvival.Players.Contracts;

    interface IChessEngine
    {
        IEnumerable<IPlayer> Players { get; } 

        void Initialize();

        void Start();

        void WinningConditions();

    }
}
