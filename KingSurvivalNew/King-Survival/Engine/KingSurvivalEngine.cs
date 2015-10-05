using KingSurvival.Commands.Contracts;
using KingSurvival.Figures;

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
        private ICommandContext context;
        
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
            Validator.ValidateGameInitialization(this.players, this.Board);
            var firstPlayer = players[0];
            var secondPlayer = players[1];
            //TODO:Cupling between factory and this class :(
           
            IFigure kingFigure = new Figure(FigureSign.K);

            var king = kingFigure.Clone();
            king.AddSign(FigureSign.K);
            firstPlayer.AddFigure(king);
            this.Board.AddFigure(king, new Position(Constants.InitialKingRow, Constants.InitialKingColumn));

            IFigure pawnFigure = new Figure(FigureSign.A);
            var pawnA = pawnFigure.Clone();
            pawnA.AddSign(FigureSign.A);
            secondPlayer.AddFigure(pawnA);
            this.Board.AddFigure(pawnA, new Position(Constants.PawnAInitialRow, Constants.PawnAInitialCol));

            var pawnB = pawnFigure.Clone();
            pawnB.AddSign(FigureSign.B);
            secondPlayer.AddFigure(pawnB);
            this.Board.AddFigure(pawnB, new Position(Constants.PawnBInitialRow, Constants.PawnBInitialCol));

            var pawnC = pawnFigure.Clone();
            pawnC.AddSign(FigureSign.C);
            secondPlayer.AddFigure(pawnC);
            this.Board.AddFigure(pawnC, new Position(Constants.PawnCInitialRow, Constants.PawnCInitialCol));

            var pawnD = pawnFigure.Clone();
            pawnD.AddSign(FigureSign.D);
            secondPlayer.AddFigure(pawnD);
            this.Board.AddFigure(pawnD, new Position(Constants.PawnDInitialRow, Constants.PawnDInitialCol));
            
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
                    //TODO:Get this context from constructor ..do not initialize here
                    context = new CommandContext(this.memory, this.Board, player);
                    this.provider.PrintPlayerNameForNextMove(context.Player.Name);
                    var commandName = this.provider.GetCommandName;
                    player.ExecuteCommand(this.context,commandName);
                   
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
