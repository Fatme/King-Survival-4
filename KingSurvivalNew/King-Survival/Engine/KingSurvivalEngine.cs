namespace KingSurvival.Engine
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.FigureFactory;
    using KingSurvival.Engine.Contracts;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Board;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Renderers.Contracts;

    public class KingSurvivalEngine : IChessEngine
    {
        private const int BoardTotalNUmberOfColumns = 8;
        private const int BoardTotalNUmberOfRows = 8;

        private readonly IRenderer renderer;
        private readonly IInputProvider provider;
        private readonly IWinningConditions winningConditions;
        private IList<IPlayer> players;
        private IBoard board;
        private int currentPlayerIndex;

        public KingSurvivalEngine(IRenderer renderer, IInputProvider inputProvider,IBoard board, IWinningConditions winningConditions)
        {
            this.renderer = renderer;
            this.provider = inputProvider;
            this.winningConditions = winningConditions;
            this.board = board;
        }

        public void Initialize()
        {
            //TODO:Extract to another class and interface
            this.players = provider.GetPlayers(Constants.StandardNumberOfPlayers);
            Validator.ValidateGameInitialization(this.players, this.board);

			var kingFigureFactory = new KingFigureFactory();
			IFigure king = kingFigureFactory.CreateFigure();

			var firstPlayer = players[0];
            firstPlayer.AddFigure(king);
            this.board.AddFigure(king, new Position(Constants.initialKingRow, Constants.initialKingColumn));

			var pawnFigureFactory = new PawnFigureFactory();
			IFigure pawnA = pawnFigureFactory.CreateFigure(FigureSign.A);
			IFigure pawnB = pawnFigureFactory.CreateFigure(FigureSign.B);
			IFigure pawnC = pawnFigureFactory.CreateFigure(FigureSign.C);
			IFigure pawnD = pawnFigureFactory.CreateFigure(FigureSign.D);

			var secondPlayer = players[1];
            secondPlayer.AddFigure(pawnA);
            secondPlayer.AddFigure(pawnB);
            secondPlayer.AddFigure(pawnC);
            secondPlayer.AddFigure(pawnD);

            this.board.AddFigure(pawnA, new Position(Constants.pawnAInitialRow, Constants.pawnAInitialCol));
            this.board.AddFigure(pawnB, new Position(Constants.pawnBInitialRow, Constants.pawnBInitialCol));
            this.board.AddFigure(pawnC, new Position(Constants.pawnCInitialRow, Constants.pawnCInitialCol));
            this.board.AddFigure(pawnD, new Position(Constants.pawnDInitialRow, Constants.pawnDInitialCol));

            this.SetFirstPlayerIndex();

            this.renderer.RenderBoard(this.board);
        }

        //TODO:add the validation in validator class
        public void Start()
        {
            while (true)
            {
                try
                {
                    if (this.winningConditions.KingWon(this.players, this.board))
                    {
                        this.renderer.PrintErrorMessage("The king won");
                        break;
                    }

                    if (this.winningConditions.KingLost(this.players, this.board))
                    {
                        this.renderer.PrintErrorMessage("The king lost");
                        break;
                    }

                    var player = this.GetNextPlayer();
                    Move move = this.provider.GetNextFigureMove(player, this.board);
                    var from = move.From;
                    var to = move.To;

                    Validator.CheckIfPositionValid(to, GlobalErrorMessages.PositionNotValidMessage);
                    Validator.CheckIfFigureOnTheWay(to, this.board, GlobalErrorMessages.FigureOnTheWayErrorMessage);

                    var figure = this.board.GetFigureAtPosition(from);

                    this.board.RemoveFigure(figure, from);
                    this.board.AddFigure(figure, to);

                    this.renderer.RenderBoard(this.board);
                }
                catch (IndexOutOfRangeException ex)
                {
                    this.HandleException(this.board, ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.HandleException(this.board, ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    this.HandleException(this.board, ex.Message);
                }
                catch (ArgumentException ex)
                {
                    this.HandleException(this.board, ex.Message);
                }
            }
        }

        private void HandleException(IBoard board, string message)
        {
            this.currentPlayerIndex--;
            this.renderer.RenderBoard(this.board);
            this.renderer.PrintErrorMessage(message);
        }

        private IPlayer GetNextPlayer()
        {
            if (currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }
            var currentPlayer = this.players[this.currentPlayerIndex];
            this.currentPlayerIndex++;
            return currentPlayer;
        }

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Figures[i].Sign == FigureSign.K)
                {
                    this.currentPlayerIndex = i;
                    return;
                }
            }
        }
    }
}
