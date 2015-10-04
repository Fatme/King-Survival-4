using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Board.Contracts
{
    public interface IBoardPrototype
    {
        IBoard Clone();
    }
}
