namespace KingSurvival.Players
{
    using System;
    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
using System.Collections.Generic;
    using KingSurvival.Common.Contracts;

    public class KingPlayer : Player, IPlayer
    {
        public KingPlayer(string name)
            : base(name)
        {
        }

        public override IDictionary<string, int> MapCommandToDirection
        {
            get
            {
                return new Dictionary<string, int>() {
                    { "kur", 0 },
                    { "kdr", 1 },
                    { "kdl", 2 },
                    { "kul", 3 }
                };
            }
        }

        public override Move Move(ICommand command, IBoard board)
        {
            var oldPosition = board.GetFigurePosition(this.Figures[0]);
            return this.GenerateNewMove(oldPosition, this.MapCommandToDirection[command.Name]);
        }
    }
}
