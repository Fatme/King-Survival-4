namespace KingSurvival.Engine.Contexts
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Engine.Contracts;

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
