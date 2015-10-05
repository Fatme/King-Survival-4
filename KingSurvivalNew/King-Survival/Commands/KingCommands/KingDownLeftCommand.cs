﻿namespace KingSurvival.Commands
{
    using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;

    public class KingDownLeftCommand : MoveCommand, IPlayerCommand
    {
        public KingDownLeftCommand()
            : base(0,2)
        { 
        }

        public override string Name
        {
            get { return "kdl"; }
        }

        
    }
}
