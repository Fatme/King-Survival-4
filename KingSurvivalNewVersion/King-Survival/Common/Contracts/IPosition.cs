using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival.Common.Contracts
{
    public interface IPosition
    {
         int Row { get; }
         int Col { get;}
    }
}
