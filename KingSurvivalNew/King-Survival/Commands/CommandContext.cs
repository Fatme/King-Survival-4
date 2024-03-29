﻿namespace KingSurvival.Commands
{
    using KingSurvival.Board;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Players.Contracts;

    public class CommandContext : ICommandContext
    {
        public CommandContext(BoardMemory memento, IBoard board, IPlayer player)
        {
            this.Memory = memento;
            this.Board = board;
            this.Player = player;
        }

        public BoardMemory Memory { get;  set; }

        public IBoard Board { get;  set; }

        public IPlayer Player { get; set; }
    }
}
