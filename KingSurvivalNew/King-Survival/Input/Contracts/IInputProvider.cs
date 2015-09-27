namespace KingSurvival.Input.Contracts
{
    using System.Collections.Generic;

    using KingSurvival.Players.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Board.Contracts;

   public interface IInputProvider
   {
        IList<IPlayer> GetPlayers(int numberOfPlayers);
       
        Move GetNextFigureMove(IPlayer player, IBoard board);
   }
}
