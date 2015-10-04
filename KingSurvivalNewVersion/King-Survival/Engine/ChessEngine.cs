using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Board.Contracts;
using KingSurvival.Engine.Contracts;
using KingSurvival.Input.Contracts;
using KingSurvival.Renderers.Contracts;

namespace KingSurvival.Engine
{
    public abstract class ChessEngine : IChessEngine
    {
        protected readonly IBoard Board;

        protected ChessEngine(IBoard board)
        {
            this.Board = board;
        }
        public abstract void Initialize();

        public abstract void Start();

    }
}
