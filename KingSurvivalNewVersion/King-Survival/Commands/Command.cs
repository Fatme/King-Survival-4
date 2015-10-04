using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Commands.Contracts;

namespace KingSurvival.Commands
{
    public abstract class Command : ICommand
    {
        public abstract string Name { get; }

        public abstract void Execute();

    }
}
