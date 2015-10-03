using KingSurvival.Commands.Contracts;

namespace KingSurvival.Players
{
    using System;

    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
    using System.Collections.Generic;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Figures.Contracts;

    public class PawnPlayer : Player, IPlayer
    {
        public PawnPlayer(string name)
            : base(name)
        {
        }
    }
}
