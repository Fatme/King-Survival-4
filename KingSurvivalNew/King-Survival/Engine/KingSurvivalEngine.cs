namespace KingSurvival.Engine
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using KingSurvival.Engine.Contracts;
    using KingSurvival.Players.Contracts;
    using Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Figures;
    using KingSurvival.Renderers.Contracts;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Board;


    public class KingSurvivalEngine : IChessEngine
    {

        private const int BoardTotalNUmberOfColumns = 8;
        private const int BoardTotalNUmberOfRows = 8;

        private IEnumerable<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider provider;


        public KingSurvivalEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.provider = inputProvider;
        }

        public IEnumerable<IPlayer> Players
        {
            get { throw new NotImplementedException(); }
        }

        public void Initialize(IBoard board)
        {
            var players = provider.GetPlayers(Constants.StandardNumberOfPlayers);

            this.ValidateGameInitialization(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];

            for (var i = 0; i < BoardTotalNUmberOfColumns; i += 2)
            {
                var pawn = new Pawn(firstPlayer.Color);
                firstPlayer.AddFigure(pawn);
                var positionPawn = new Position(8, (char)(i + 'a'));
                board.AddFigure(pawn, positionPawn);
            }

            var king = new King(secondPlayer.Color);
            var positionKing = new Position(1, 'd');
            secondPlayer.AddFigure(king);
            board.AddFigure(king, positionKing);
        }
        private void ValidateGameInitialization(ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count == Constants.StandardNumberOfPlayers)
            {
                throw new InvalidOperationException("King Survival Engine must have two player");
            }

            if (board.NumberOfRows != BoardTotalNUmberOfRows || board.NumberOfColumns != BoardTotalNUmberOfColumns)
            {
                throw new InvalidOperationException("King survial has 8x8 board");
            }
        }
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void WinningConditions()
        {
            throw new NotImplementedException();
        }


        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
