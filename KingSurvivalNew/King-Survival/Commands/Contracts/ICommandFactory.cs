using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Commands.Contracts
{
    interface ICommandFactory
    {
        ICommand CreatePlayerCommand(string commandName);
    }
}
