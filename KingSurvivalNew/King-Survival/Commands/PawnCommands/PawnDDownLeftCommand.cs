using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Commands
{
    public class PawnDDownLeftCommand : Command, IPlayerCommand
    {
        public PawnDDownLeftCommand(IBoard board)
            : base(board)
        {
        }

        public string Name
        {
            get { return "ddl"; }
        }

        public int Direction
        {
            get { return 2; }
        }

        public int FigureIndex
        {
            get { return 3; }
        }
    }
}
