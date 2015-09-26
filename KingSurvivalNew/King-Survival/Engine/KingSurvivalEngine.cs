using KingSurvival.Renderers.Contracts;

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

    public class KingSurvivalEngine : IChessEngine
    {

        private const int BoardTotalNUmberOfColumns = 8;
        private const int BoardTotalNUmberOfRows = 8;

        private readonly IRenderer renderer;
        private readonly IInputProvider provider;
        private IList<IPlayer> players;
        private IBoard board;

        private int currentPlayerIndex;

        public KingSurvivalEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.provider = inputProvider;
            board = new Board();
        }

        public void Initialize()
        {
            //TODO:Extract to another class and interface
            this.players = provider.GetPlayers(Constants.StandardNumberOfPlayers);

            Validator.ValidateGameInitialization(this.players, this.board);

            var firstPlayer = players[0];
            IFigure king = new KingFigureFactory().CreateFigure(FigureSign.K);
            firstPlayer.AddFigure(king);
            this.board.AddFigure(king,new Position(Constants.initialKingRow,Constants.initialKingColumn));

            var secondPlayer = players[1];
            IFigure pawnA = new PawnFigureFactory().CreateFigure(FigureSign.A);
            IFigure pawnB = new PawnFigureFactory().CreateFigure(FigureSign.B);
            IFigure pawnC = new PawnFigureFactory().CreateFigure(FigureSign.C);
            IFigure pawnD = new PawnFigureFactory().CreateFigure(FigureSign.D);
            secondPlayer.AddFigure(pawnA);
            secondPlayer.AddFigure(pawnB);
            secondPlayer.AddFigure(pawnC);
            secondPlayer.AddFigure(pawnD);
            this.board.AddFigure(pawnA,new Position(Constants.pawnAInitialRow,Constants.pawnAInitialCol));
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
                    var player = this.GetNextPlayer();

                    Move move = this.provider.GetNextMoveFigure(player,this.board);
                    var from = move.From;
                    var to = move.To;
                    Position.CheckIfValid(to, GlobalErrorMessages.PositionNotValidMessage);
                    var figure = this.board.GetFigureAtPosition(from);
                    this.board.RemoveFigure(figure,from);
                    this.board.AddFigure(figure,to);

                    this.renderer.RenderBoard(this.board);

                    if (WinningConditions())
                    {
                        this.renderer.PrintErrorMessage("The king won");
                        break;
                    }


                }
                catch (IndexOutOfRangeException ex)
                {
                    currentPlayerIndex--;
                    this.renderer.RenderBoard(this.board);
                    this.renderer.PrintErrorMessage(ex.Message);

                }
                catch (ArgumentOutOfRangeException ex)
                {
                    currentPlayerIndex--;
                    this.renderer.RenderBoard(this.board);
                    this.renderer.PrintErrorMessage(ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    currentPlayerIndex--;
                    this.renderer.RenderBoard(this.board);
                    this.renderer.PrintErrorMessage(ex.Message);
                }

            }

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

        public bool WinningConditions()
        {
            if (KingWon())
            {
                return true;
            }
            return false;
            //TODO:Add more conditions

        }
        public bool KingWon()
        {
            for(var i = 0; i < players.Count; i++)
            {
                if (players[i].Figures[0].Sign == FigureSign.K)
                {
                    if (this.board.GetFigurePosition(players[i].Figures[0]).Row == 0)//check if king is on the first row
                    {
                        return true;
                    }
                }
            }
           

            return false;
            ////TODO:Add the rest of the conditions
        }

    }
}
