using KingSurvival.Common;
using KingSurvival.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Figures.Contracts
{
    interface IMoveable
    {
        Move Move(string command);
    }
}
