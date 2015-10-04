using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Commands
{
    public class PawnCDownLeftCommand : MoveCommand, IPlayerCommand
    {
        public PawnCDownLeftCommand(ICommandContext context)
            : base(context,2,2)
        {
        }

        public override string Name
        {
            get { return "cdl"; }
        }

    }
}
