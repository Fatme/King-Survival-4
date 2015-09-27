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
        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();
            //for (int i = 0; i < numberOfPlayers; i++)
            // {
            //Console.Clear();
            //Console.Write(string.Format("Enter player {0} name ", i));
            //string name = Console.ReadLine();

            var kingPlayer = new KingPlayer("King");
            var pawnPlayer = new PawnPlayer("Pawn");
            players.Add(kingPlayer);
            players.Add(pawnPlayer);
            // }
            return players;
        }

      
        public Move GetNextFigureMove(IPlayer player,IBoard board)
        {
            Console.Write("{0} is next ", player.Name);
            var command = Console.ReadLine();
            Move move = player.Move(command,board);
            return move;

        }
      
       

    }
}
