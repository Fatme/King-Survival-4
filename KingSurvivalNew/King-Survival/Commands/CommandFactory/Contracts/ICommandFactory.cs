using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Commands.Contracts;

namespace KingSurvival.Commands.CommandFactory.Contracts
{
    interface ICommandFactory
    {
        ICommand CreatePlayerCommand(string commandName);
    }
}
