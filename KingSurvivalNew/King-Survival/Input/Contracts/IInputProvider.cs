namespace KingSurvival.Input.Contracts
{
    using System.Collections.Generic;

    using KingSurvival.Players.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Board.Contracts;

   public interface IInputProvider
   {
       string GetPlayerName { get; }

       string GetCommandName { get;  }

       void PrintPlayerNameForNextMove(string playerName);
   }
}
