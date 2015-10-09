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

        public CommandFactory()
        {
            this.commands = new Dictionary<string, ICommand>();
        }

        public ICommand CreatePlayerCommand(string commandName)
        {
            ICommand resultCommand;

            if (this.commands.ContainsKey(commandName))
            {
                return this.commands[commandName];
            }

            switch (commandName.ToLower())
            {
                case "kdl":
                    resultCommand = new KingDownLeftCommand();
                    break;
                case "kdr":
                    resultCommand = new KingDownRightCommand();
                    break;
                case "kul":
                    resultCommand = new KingUpLeftCommand();
                    break;
                case "kur":
                    resultCommand = new KingUpRightCommand();
                    break;
                case "adl":
                    resultCommand = new PawnADownLeftCommand();
                    break;
                case "adr":
                    resultCommand = new PawnADownRightCommand();
                    break;
                case "bdl":
                    resultCommand = new PawnBDownLeftCommand();
                    break;
                case "bdr":
                    resultCommand = new PawnBDownRightCommand();
                    break;
                case "cdl":
                    resultCommand = new PawnCDownLeftCommand();
                    break;
                case "cdr":
                    resultCommand = new PawnCDownRightCommand();
                    break;
                case "ddl":
                    resultCommand = new PawnDDownLeftCommand();
                    break;
                case "ddr":
                    resultCommand = new PawnDDownRightCommand();
                    break;
                case "undo":
                    resultCommand = new UndoCommand();
                    break;
                default:
                    throw new ArgumentException("Incorect command " + commandName);
            }

            this.commands.Add(commandName, resultCommand);
            return resultCommand;
        }
    }
}
