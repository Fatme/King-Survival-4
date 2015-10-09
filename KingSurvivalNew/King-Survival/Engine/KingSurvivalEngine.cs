namespace KingSurvival.Engine
{
    using System.Collections.Generic;

    using KingSurvival.Board.Contracts;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Engine.Contexts;
    using KingSurvival.Engine.Contracts;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Renderers.Contracts;

    public class KingSurvivalEngine : ChessEngine, IChessEngine
    {
        private readonly KingSurvivalEngineContext context;

        public KingSurvivalEngine(IRenderer renderer, IInputProvider inputProvider, IBoard board, IWinningConditions winningCondition, IList<IPlayer> players)
            : base(board)
        {
            this.context = new KingSurvivalEngineContext(renderer, inputProvider, board, winningCondition, players);
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
