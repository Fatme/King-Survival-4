using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Board;
using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;
using KingSurvival.Common;

namespace KingSurvival.Commands
{
    class UndoCommand :Command, ICommand
    {
        private ICommandContext context;
        public UndoCommand(ICommandContext context)
        {
            this.context = context;
        }

        public override string Name
        {
            get { return "undo"; }
        }

        public override void Execute()
        {
            if (this.context.Memory.Memento != null)
            {
                this.context.Board.RestoreMemento(this.context.Memory.Memento);
                
            }


        }

    }
}
