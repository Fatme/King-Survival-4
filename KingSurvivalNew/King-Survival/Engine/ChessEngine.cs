namespace KingSurvival.Engine
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Engine.Contracts;

    public abstract class ChessEngine : IChessEngine
    {
        protected readonly IBoard Board;

        protected ChessEngine(IBoard board)
        {
            this.Board = board;
        }

        public abstract IChessEngine InitializeGame();

        public abstract IChessEngine StartGame();
    }
}
