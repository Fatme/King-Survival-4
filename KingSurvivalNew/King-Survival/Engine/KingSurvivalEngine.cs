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

    public class KingSurvivalEngine : IKingSurvivalEngine
    {
        private readonly KingSurvivalEngineContext context;
        protected readonly IBoard Board;

        public KingSurvivalEngine(IRenderer renderer, IInputProvider inputProvider, IBoard board, IWinningConditions winningCondition, IList<IPlayer> players)
        {
            this.context = new KingSurvivalEngineContext(renderer, inputProvider, board, winningCondition, players);
            this.Board = board;
        }

        public IKingSurvivalEngine InitializeGame()
        {
            this.context.Initialize();
            return this;
        }

        public IKingSurvivalEngine StartGame()
        {
            this.context.Start();
            return this;
        }
    }
}
