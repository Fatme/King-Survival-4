using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Common;
using KingSurvival.Input.Contracts;
using KingSurvival.Players;
using KingSurvival.Players.Contracts;

namespace KingSurvival.Input
{
    public class ConsoleInputProvider:IInputProvider
    {
        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Clear();
                Console.Write(string.Format("Enter player {0} name ", i));
                string name = Console.ReadLine();

                var player = new Player(name, (ChessColor)(i));
                players.Add(player);
            }
            return players;
        }
    }
}
