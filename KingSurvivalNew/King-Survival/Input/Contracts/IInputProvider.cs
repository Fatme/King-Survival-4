namespace KingSurvival.Input.Contracts
{
    using KingSurvival.Players.Contracts;
    using System.Collections.Generic;
    using KingSurvival.Common;

   public interface IInputProvider
   {
        IList<IPlayer> GetPlayers(int numberOfPlayers);

        Move GetNextMoveFigure(IPlayer player);
   }
}
