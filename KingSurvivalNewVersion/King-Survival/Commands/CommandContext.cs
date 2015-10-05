using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Board;
using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;
using KingSurvival.Common;
using KingSurvival.Input.Contracts;
using KingSurvival.Players.Contracts;

namespace KingSurvival.Commands
{
    public class CommandContext : ICommandContext
    {

        public CommandContext(BoardMemory memento, IBoard board, IPlayer player,IInputProvider provider)
        {
            this.Memory = memento;
            this.Board = board;
            this.Player = player;
            this.Provier = provider;
        }

        public BoardMemory Memory { get; private set; }


        public IBoard Board { get; private set; }


        public IPlayer Player { get; set; }


        public IInputProvider Provier { get; private set; }
    }
}
