using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Commands
{
    public class PawnBDownLeftCommand : Command, IPlayerCommand
    {
        public PawnBDownLeftCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "bdl"; }
        }

        public int Direction
        {
            get { return 2; }
        }

        public int FigureIndex
        {
            get { return 1; }
        }
    }
}
