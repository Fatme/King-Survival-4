using KingSurvival.Board.Contracts;
using KingSurvival.Commands.Contracts;
using KingSurvival.Common;
using KingSurvival.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private readonly Dictionary<string, ICommand> commands;

        public CommandFactory()
        {
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
                {"undo",new UndoCommand()}
            };
        }

        public ICommand CreatePlayerCommand(string commandName)
        {
            var commandNameLowerCase = commandName.ToLower();
            this.ValidePlayerCommand(commandNameLowerCase);
            return this.commands[commandNameLowerCase];
        }

        private void ValidePlayerCommand(string commandName)
        {
        //    if (commandName.Length != 3)
        //    {
        //        //TODO: change the exception to custom exception
        //        throw new ArgumentOutOfRangeException(GlobalErrorMessages.CommandCanBeThreeSymbolsOnlyMessage);
        //    }

            //if (!this.commands.Keys.Contains(commandName))
            //{
            //    //TODO: change the exception to custom exception
            //    throw new ArgumentOutOfRangeException(string.Format(GlobalErrorMessages.CommandNotCorrectMessage, string.Join(", ", this.commands.Keys)));
            //}
        }
    }
}
