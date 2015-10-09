using System;
using System.Collections;
using KingSurvival.Common.Contracts;
using KingSurvival.Players.Contracts;
using KingSurvival.Renderers.Contracts;

namespace KingSurvival.Engine.Contexts
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Engine.Contracts;
    using System.Collections.Generic;

    public abstract class ChessEngineContext : IChessEngineContext
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
