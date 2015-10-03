namespace KingSurvival.Players
{
    using System;
    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
    using System.Collections.Generic;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Commands.Contracts;

    public class KingPlayer : Player, IPlayer
    {
        public KingPlayer(string name)
            : base(name)
        {
        }
    }
}
