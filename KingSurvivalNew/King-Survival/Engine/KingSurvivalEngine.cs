using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KingSurvival.Board.Contracts;
using KingSurvival.Common.Contracts;
using KingSurvival.Engine.Contexts;
using KingSurvival.Engine.Contracts;
using KingSurvival.Input.Contracts;
using KingSurvival.Renderers.Contracts;

namespace KingSurvival.Engine
{
    public class KingSurvivalEngine:ChessEngine,IChessEngine
    {
        private readonly KingSurvivalEngineContext context;
       
        public KingSurvivalEngine(IRenderer renderer, IInputProvider inputProvider, IBoard board, IWinningConditions winningCondition)
            : base(board)
        {
            this.context=new KingSurvivalEngineContext(renderer,inputProvider,board,winningCondition);
        }

        public override IChessEngine InitializeGame()
        {
             this.context.Initialize();
            return this;
        }

        public override IChessEngine StartGame()
        {
           this.context.Start();
            return this;
        }
        
    }
}
