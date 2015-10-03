using KingSurvival.Commands.Contracts;

namespace KingSurvival.Players
{
    using System;

    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
    using System.Collections.Generic;
    using KingSurvival.Common.Contracts;

    public class PawnPlayer : Player, IPlayer
    {
        public PawnPlayer(string name)
            : base(name)
        {
        }
        //TODO:The player should not know about the commands..Move it from here
        public override IDictionary<string, int> MapCommandToDirection
        {
            get
            {
                return new Dictionary<string, int>() {
                    { "adr", 1 },
                    { "bdr", 1 },
                    { "cdr", 1 },
                    { "ddr", 1 },
                    { "adl", 2 },
                    { "bdl", 2 },
                    { "cdl", 2 },
                    { "ddl", 2 }
                };
            }
        }
        
        public override Move Move(ICommand command, IBoard board)
        {
            int pawnIndex = -1;
            switch (command.Name[0])
            {
                case 'a':
                case 'A':
                    { pawnIndex = 0; }
                    break;
                case 'b':
                case 'B':
                    { pawnIndex = 1; }
                    break;
                case 'c':
                case 'C':
                    { pawnIndex = 2; }
                    break;
                case 'd':
                case 'D':
                    { pawnIndex = 3; }
                    break;
            }

            var oldPosition = board.GetFigurePosition(this.Figures[pawnIndex]);
            return this.GenerateNewMove(oldPosition, this.MapCommandToDirection[command.Name]);
        } 
    }
}
