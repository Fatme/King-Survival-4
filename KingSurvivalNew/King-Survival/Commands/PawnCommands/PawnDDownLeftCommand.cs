using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Commands
{
    public class PawnDDownLeftCommand : MoveCommand, IPlayerCommand
    {
        public PawnDDownLeftCommand()
            : base(3,2)
        {
        }

        public override string Name
        {
            get { return "ddl"; }
        }

    }
}
