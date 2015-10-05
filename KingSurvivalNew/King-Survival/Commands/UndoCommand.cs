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
      
        public UndoCommand()
        {
           
        }

        public override string Name
        {
            get { return "undo"; }
        }

        public override void Execute(ICommandContext context)
        {
            if (context.Memory.Memento != null)
            {
                context.Board.RestoreMemento(context.Memory.Memento);
                
            }


        }

    }
}
