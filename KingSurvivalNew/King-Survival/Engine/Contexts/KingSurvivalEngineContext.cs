namespace KingSurvival.Engine.Contexts
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.Board;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands;
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Engine.Contracts;
    using KingSurvival.Figures;
    using KingSurvival.Input.Contracts;
    using KingSurvival.Players;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Renderers.Contracts;

    public class KingSurvivalEngineContext : ChessEngineContext, IChessEngineContext
    {
        private readonly IRenderer renderer;
        private readonly IInputProvider provider;
        private readonly IWinningConditions winningConditions;
        private IPlayer kingPlayer;
        private IPlayer pawnPlayer;
        private ICommandContext context;
        private IList<IPlayer> players;
        private int currentPlayerIndex;
        private BoardMemory memory;

        public KingSurvivalEngineContext(IRenderer renderer, IInputProvider inputProvider, IBoard board, IWinningConditions winningConditions)
            : base(board)
        {
            this.renderer = renderer;
            this.provider = inputProvider;
            this.winningConditions = winningConditions;
            this.memory = new BoardMemory();
            this.currentPlayerIndex = 0;
            
        }

        public override void Initialize()
        {
            this.players = new List<IPlayer>();
            this.kingPlayer = new Player("king");
            this.pawnPlayer = new Player("pawn");
            this.players.Add(this.kingPlayer);
            this.players.Add(this.pawnPlayer);
            Validator.ValidateGameInitialization(this.players, this.Board);

            KingFigure kingFigure = new KingFigure();
            PawnAFigure pawnA = new PawnAFigure();
            PawnBFigure pawnB = new PawnBFigure();
            PawnCFigure pawnC = new PawnCFigure();
            PawnDFigure pawnD = new PawnDFigure();

            this.Board.AddFigure(kingFigure, new Position(Constants.InitialKingRow, Constants.InitialKingColumn));
            this.Board.AddFigure(pawnA, new Position(Constants.PawnAInitialRow, Constants.PawnAInitialCol));
            this.Board.AddFigure(pawnB, new Position(Constants.PawnBInitialRow, Constants.PawnBInitialCol));
            this.Board.AddFigure(pawnC, new Position(Constants.PawnCInitialRow, Constants.PawnCInitialCol));
            this.Board.AddFigure(pawnD, new Position(Constants.PawnDInitialRow, Constants.PawnDInitialCol));

            this.kingPlayer.AddFigure(kingFigure);

            this.pawnPlayer.AddFigure(pawnA);
            this.pawnPlayer.AddFigure(pawnB);
            this.pawnPlayer.AddFigure(pawnC);
            this.pawnPlayer.AddFigure(pawnD);

            this.renderer.RenderBoard(this.Board);
        }

        public override void Start()
        {
            IPlayer player = null;

            while (true)
            {
                try
                {
                    if (this.winningConditions.KingWon(this.players, this.Board))
                    {
                        this.renderer.PrintMessage("The king won with " + player.MovesCount + " valid commands");
                        break;
                    }

                    if (this.winningConditions.KingLost(this.players, this.Board))
                    {
                        this.renderer.PrintMessage("The king lost");
                        break;
                    }

                    player = this.GetNextPlayer();

                    this.context = new CommandContext(this.memory, this.Board, player);
                    this.provider.PrintPlayerNameForNextMove(this.context.Player.Name);
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
            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            var currentPlayer = this.players[this.currentPlayerIndex];
            this.currentPlayerIndex++;
            return currentPlayer;
        }
    }
}