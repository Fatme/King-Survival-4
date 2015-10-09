namespace KingSurvival.Commands.CommandFactory
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.Commands.CommandFactory.Contracts;
    using KingSurvival.Commands.CommonCommands;
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Commands.KingCommands;
    using KingSurvival.Commands.PawnCommands;

    public class CommandFactory : ICommandFactory
    {
        private readonly Dictionary<string, ICommand> commands;
        private readonly IDictionary<string, ICommand> executedCommands;

        public CommandFactory()
        {
            this.executedCommands = new Dictionary<string, ICommand>();
            this.commands = new Dictionary<string, ICommand>()
            {
               { "kdl", new KingDownLeftCommand() },
               { "kdr", new KingDownRightCommand() },
               { "kul", new KingUpLeftCommand() },
               { "kur", new KingUpRightCommand() },
               { "adl", new PawnADownLeftCommand() },
               { "adr", new PawnADownRightCommand() },
               { "bdl", new PawnBDownLeftCommand() },
               { "bdr", new PawnBDownRightCommand() },
               { "cdl", new PawnCDownLeftCommand() },
               { "cdr", new PawnCDownRightCommand() },
               { "ddl", new PawnDDownLeftCommand() },
               { "ddr", new PawnDDownRightCommand() },
               { "undo", new UndoCommand() }
           }; 
        }

        public ICommand CreatePlayerCommand(string commandName)
        {
            var commandLowerCase = commandName.ToLower();

            if (this.executedCommands.ContainsKey(commandLowerCase))
            {
                return this.executedCommands[commandLowerCase];
            }

            ICommand command;
            if (!this.commands.TryGetValue(commandLowerCase, out command))
            {
                throw new ArgumentException("Incorrect command " + commandName);
            }

            this.executedCommands.Add(commandLowerCase, command);

            return command;
        }
    }
}
