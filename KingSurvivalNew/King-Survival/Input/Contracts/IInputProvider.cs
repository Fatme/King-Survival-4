namespace KingSurvival.Input.Contracts
{
    using KingSurvival.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using KingSurvival.Common;

   public interface IInputProvider
   {
        IList<IPlayer> GetPlayers(int numberOfPlayers);

        Move GetNextMoveFigure(IPlayer player);
   }
}
