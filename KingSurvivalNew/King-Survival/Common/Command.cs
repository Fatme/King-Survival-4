using KingSurvival.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Common
{
    public class Command : ICommand
    {
        public string Name { get; private set; }

        public Command(string name, ICollection<string> supportedCommands)
        {
            if (name.Length != 3)
            {
                //TODO: change the exception to custom exception
                throw new ArgumentOutOfRangeException("The command should contain three symbols.");
            }

            if (!supportedCommands.Contains(name))
            {
                //TODO: change the exception to custom exception
                throw new ArgumentOutOfRangeException("The command is not correct. The valid commands are {0}.", string.Join(", ", supportedCommands));
            }

            this.Name = name;
        }
    }
}
