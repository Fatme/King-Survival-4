using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Board;
using KingSurvival.Board.Contracts;
using KingSurvival.Common;
using KingSurvival.Input.Contracts;
using KingSurvival.Players.Contracts;

namespace KingSurvival.Commands.Contracts
{
    public interface ICommandContext
    {
        BoardMemory Memory { get; }

        IBoard Board { get; }

        IPlayer Player { get; set; }

        
    }
}
