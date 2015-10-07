using KingSurvival.Commands.Contracts;
using KingSurvival.Engine.Contexts;
using KingSurvival.Figures;

namespace KingSurvival.Engine.Contexts
{
    using System;
    using System.Collections.Generic;


    using KingSurvival.Engine.Contracts;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Board;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Renderers.Contracts;

    using KingSurvival.Players;
    using KingSurvival.Commands;

    public class KingSurvivalEngineContext :ChessEngineContext,IChessEngineContext
    {
        private const int BoardTotalNUmberOfColumns = 8;
        private const int BoardTotalNUmberOfRows = 8;

        private readonly IRenderer renderer;
        private readonly IInputProvider provider;
        private readonly IWinningConditions winningConditions;
        private IList<IPlayer> players;
        private IPlayer kingPlayer;
        private IPlayer pawnPlayer;
        private ICommandContext context;

        private int currentPlayerIndex;
        private BoardMemory memory = new BoardMemory();


        public KingSurvivalEngineContext(IRenderer renderer, IInputProvider inputProvider, IBoard board, IWinningConditions winningConditions)
            : base(board)
        {
            this.renderer = renderer;
            this.provider = inputProvider;
            this.winningConditions = winningConditions;

        }
        //TODO:think about move this function in the parent class
        public override void Initialize()
        {
            //TODO:Extract to another class and interface
            this.players = this.CreatePlayers();
            this.kingPlayer = this.players[0];
            this.pawnPlayer = this.players[1];
            Validator.ValidateGameInitialization(this.players, this.Board);


            IFigure figure = new Figure(FigureSign.K);
            this.AddFigureOnTheBoard(figure, FigureSign.K, new Position(Constants.InitialKingRow, Constants.InitialKingColumn));
            this.AddFigureOnTheBoard(figure, FigureSign.A, new Position(Constants.PawnAInitialRow, Constants.PawnAInitialCol));
            this.AddFigureOnTheBoard(figure, FigureSign.B, new Position(Constants.PawnBInitialRow, Constants.PawnBInitialCol));
            this.AddFigureOnTheBoard(figure, FigureSign.C, new Position(Constants.PawnCInitialRow, Constants.PawnCInitialCol));
            this.AddFigureOnTheBoard(figure, FigureSign.D, new Position(Constants.PawnDInitialRow, Constants.PawnDInitialCol));

            this.SetFirstPlayerIndex();

            this.renderer.RenderBoard(this.Board);
        }
        private void AddFigureOnTheBoard(IFigure figure, FigureSign figureSing, Position position)
        {
            var newFigure = figure.Clone();
            newFigure.AddSign(figureSing);

            if (figureSing == FigureSign.K)
            {
                this.kingPlayer.AddFigure(newFigure);
            }
            else
            {
                this.pawnPlayer.AddFigure(newFigure);
            }

            this.Board.AddFigure(newFigure, position);
        }
        //TODO:think about move this function in the parent class
        public override void Start()
        {
            IPlayer player = null;
           
            while (true)
            {
                try
                {

                    if (this.winningConditions.KingWon(this.players, this.Board))
                    {
                        this.renderer.PrintMessage("The king won with "+player.MovesCount+" valid commands");
                        break;
                    }

                    if (this.winningConditions.KingLost(this.players, this.Board))
                    {
                        this.renderer.PrintMessage("The king lost");
                        break;
                    }

                    player = this.GetNextPlayer();
                    //TODO:Get this context from constructor ..do not initialize here
                    context = new CommandContext(this.memory, this.Board, player);
                    this.provider.PrintPlayerNameForNextMove(context.Player.Name);
                    var commandName = this.provider.GetCommandName;
                    player.ExecuteCommand(this.context, commandName);

                    this.renderer.RenderBoard(this.Board);
                }
                catch (IndexOutOfRangeException ex)
                {
                    this.HandleException(this.Board, ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.HandleException(this.Board, ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    this.HandleException(this.Board, ex.Message);
                }
                catch (ArgumentException ex)
                {
                    this.HandleException(this.Board, ex.Message);
                }
            }
        }

        private void HandleException(IBoard board, string message)
        {
            this.currentPlayerIndex--;
            this.renderer.RenderBoard(this.Board);
            this.renderer.PrintMessage(message);
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

        private IList<IPlayer> CreatePlayers()
        {
            var players = new List<IPlayer>();

            var kingPlayer = new KingPlayer("king");
            players.Add(kingPlayer);

            var pawnPlayer = new PawnPlayer("pawn");
            players.Add(pawnPlayer);

            return players;
        }


    }
}
