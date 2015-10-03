using KingSurvival.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Commands.Contracts;
using KingSurvival.Common;

namespace KingSurvival.Commands
{
    public class Command : ICommand
    {
        public string Name { get; private set; }

        public Command(string name, ICollection<string> supportedCommands)
        {
            if (name.Length != 3)
            {
                //TODO: change the exception to custom exception
                throw new ArgumentOutOfRangeException(GlobalErrorMessages.CommandCanBeThreeSymbolsOnlyMessage);
            }

            if (!supportedCommands.Contains(name))
            {
                //TODO: change the exception to custom exception
                throw new ArgumentOutOfRangeException(string.Format(GlobalErrorMessages.CommandNotCorrectMessage,string.Join(", ", supportedCommands)));
            }

            this.Name = name;
        }
    }
}
