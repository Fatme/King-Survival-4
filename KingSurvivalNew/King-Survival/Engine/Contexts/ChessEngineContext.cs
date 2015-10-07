using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Board.Contracts;
using KingSurvival.Engine.Contracts;

namespace KingSurvival.Engine.Contexts
{
   public abstract class ChessEngineContext:IChessEngineContext
   {
        protected readonly IBoard Board;

        protected ChessEngineContext(IBoard board)
        {
            this.Board = board;
        }
       public abstract void Initialize();

       public abstract void Start();

   }
}
