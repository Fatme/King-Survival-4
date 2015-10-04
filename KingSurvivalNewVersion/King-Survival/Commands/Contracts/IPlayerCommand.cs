using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Commands.Contracts
{
    public interface IPlayerCommand : ICommand
    {
        int Direction { get; }

        int FigureIndex { get; }
    }
}
