namespace KingSurvival.Engine
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
    using KingSurvival.Figures;   
    using KingSurvival.Players;
    using KingSurvival.Commands;

    public class KingSurvivalEngine :ChessEngine, IChessEngine
    {
        private const int BoardTotalNUmberOfColumns = 8;
        private const int BoardTotalNUmberOfRows = 8;
        
        private readonly IRenderer renderer;
        private readonly IInputProvider provider;
        private readonly IWinningConditions winningConditions;
        private IList<IPlayer> players;
        private IPlayer kingPlayer;
        private IPlayer pawnPlayer;
        
        private int currentPlayerIndex;
        private BoardMemory memory=new BoardMemory();

        public KingSurvivalEngine(IRenderer renderer, IInputProvider inputProvider, IBoard board, IWinningConditions winningConditions):base(board)
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

            IFigure figure = new Figure();

            this.AddFigure(figure, FigureSign.K, new Position(Constants.InitialKingRow, Constants.InitialKingColumn));
            this.AddFigure(figure, FigureSign.A, new Position(Constants.PawnAInitialRow, Constants.PawnAInitialCol));
            this.AddFigure(figure, FigureSign.B, new Position(Constants.PawnBInitialRow, Constants.PawnBInitialCol));
            this.AddFigure(figure, FigureSign.C, new Position(Constants.PawnCInitialRow, Constants.PawnCInitialCol));
            this.AddFigure(figure, FigureSign.D, new Position(Constants.PawnDInitialRow, Constants.PawnDInitialCol));

            this.SetFirstPlayerIndex();
          
            this.renderer.RenderBoard(this.Board);
        }

        //TODO:think about move this function in the parent class
        public override void Start()
        {
            while (true)
            {
                try
                {
                    this.memory.Memento = this.Board.SaveMemento();
                    if (this.winningConditions.KingWon(this.players, this.Board))
                    {
                        this.renderer.PrintMessage("The king won");
                        break;
                    }

                    if (this.winningConditions.KingLost(this.players, this.Board))
                    {
                        this.renderer.PrintMessage("The king lost");
                        break;
                    }

                    var player = this.GetNextPlayer();
                    this.ExecutePlayerCommand(player);
                    
                    //TODO:this should not be here :)
                    //this.Board.RestoreMemento(this.memory.Memento);
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

        private void AddFigure(IFigure figure, FigureSign figureSing, Position position)
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

            var kingPlayer = new Player(this.provider.GetPlayerName);
            players.Add(kingPlayer);

            var pawnPlayer = new Player(this.provider.GetPlayerName);
            players.Add(pawnPlayer);

            return players;
        }

        private void ExecutePlayerCommand(IPlayer player)
        {
            this.provider.PrintPlayerNameForNextMove(player.Name);

            var commandFactory = new CommandFactory(this.Board);
            var commandName = this.provider.GetCommandName;
            var command = commandFactory.CreatePlayerCommand(commandName);
            command.Execute(player.Figures);
        }
    }
}
