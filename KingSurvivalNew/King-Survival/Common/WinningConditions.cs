using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Board.Contracts;
namespace KingSurvival.Common
{
    using KingSurvival.Common.Contracts;
    using KingSurvival.Players.Contracts;

    public class WinningConditions : IWinningConditions
    {
        public bool KingWon(IList<IPlayer> players, IBoard board)
        {
            for (var i = 0; i < players.Count; i++)
            {
                if (players[i].Figures[0].Sign == FigureSign.K)
                {
                    if (board.GetFigurePosition(players[i].Figures[0]).Row == 0)//check if king is on the first row
                    {
                        return true;
                    }
                }
            }

            return false;
            ////TODO:Add the rest of the conditions
        }

        public bool KingLost(IList<IPlayer> players, IBoard board)
        {
            //TODO:Implement this function
            throw new NotImplementedException();
        }
    }
}
