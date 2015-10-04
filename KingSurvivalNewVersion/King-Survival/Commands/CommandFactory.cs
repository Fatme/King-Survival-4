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

        public CommandFactory(ICommandContext context)
        {
            this.commands = new Dictionary<string, ICommand>()
            {
                { "kdl", new KingDownLeftCommand(context) },
                { "kdr", new KingDownRightCommand(context) },
                { "kul", new KingUpLeftCommand(context) },
                { "kur", new KingUpRightCommand(context) },
                { "adl", new PawnADownLeftCommand(context) },
                { "adr", new PawnADownRightCommand(context) },
                { "bdl", new PawnBDownLeftCommand(context) },
                { "bdr", new PawnBDownRightCommand(context) },
                { "cdl", new PawnCDownLeftCommand(context) },
                { "cdr", new PawnCDownRightCommand(context) },
                { "ddl", new PawnDDownLeftCommand(context) },
                { "ddr", new PawnDDownRightCommand(context) },
                {"undo",new UndoCommand(context)}
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
