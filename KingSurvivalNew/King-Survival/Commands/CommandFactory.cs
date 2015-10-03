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
        private readonly Dictionary<string, IPlayerCommand> commands;

        public CommandFactory(IBoard board)
        {
            this.commands = new Dictionary<string, IPlayerCommand>()
            {
                { "kdl", new KingDownLeftCommand(board) },
                { "kdr", new KingDownRightCommand(board) },
                { "kul", new KingUpLeftCommand(board) },
                { "kur", new KingUpRightCommand(board) },
                { "adl", new PawnADownLeftCommand(board) },
                { "adr", new PawnADownRightCommand(board) },
                { "bdl", new PawnBDownLeftCommand(board) },
                { "bdr", new PawnBDownRightCommand(board) },
                { "cdl", new PawnCDownLeftCommand(board) },
                { "cdr", new PawnCDownRightCommand(board) },
                { "ddl", new PawnDDownLeftCommand(board) },
                { "ddr", new PawnDDownRightCommand(board) }
            };
        }

        public IPlayerCommand CreatePlayerCommand(string commandName)
        {
            var commandNameLowerCase = commandName.ToLower();
            this.ValidePlayerCommand(commandNameLowerCase);
            return this.commands[commandNameLowerCase];
        }

        private void ValidePlayerCommand(string commandName)
        {
            if (commandName.Length != 3)
            {
                //TODO: change the exception to custom exception
                throw new ArgumentOutOfRangeException(GlobalErrorMessages.CommandCanBeThreeSymbolsOnlyMessage);
            }

            if (!this.commands.Keys.Contains(commandName))
            {
                //TODO: change the exception to custom exception
                throw new ArgumentOutOfRangeException(string.Format(GlobalErrorMessages.CommandNotCorrectMessage, string.Join(", ", this.commands.Keys)));
            }
        }
    }
}
