using KingSurvival.Common;
using KingSurvival.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Figures.Contracts
{
    //TODO:Maybe later do it the figure IMoveable not the player
    interface IMoveable
    {
        Move Move(string command);
    }
}
