namespace KingSurvival.ConsoleUI.Input
{
    using System;

    using KingSurvival.Input.Contracts;

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
