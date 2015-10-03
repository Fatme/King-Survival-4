using KingSurvival.Commands;

namespace KingSurvivalUI.Input
{
    using System;
    using System.Collections.Generic;
    
    using KingSurvival.Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Players;
    using KingSurvival.Players.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        public string GetPlayerName
        {
            get
            {
                var playerName = Console.ReadLine();
                return playerName;
            }
        }

        public string GetCommandName
        {
            get
            {
                var commandName = Console.ReadLine();
                return commandName;
            }
        }

        public void PrintPlayerNameForNextMove(string playerName)
        {
            Console.Write("{0} is next ", playerName);
        }
    }
}
