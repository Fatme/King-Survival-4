using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Commands
{
    public class PawnCDownLeftCommand : PlayerCommand, IPlayerCommand
    {
        public PawnCDownLeftCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "cdl"; }
        }

        public override int Direction
        {
            get { return 2; }
        }

        public override int FigureIndex
        {
            get { return 2; }
        }
    }
}
