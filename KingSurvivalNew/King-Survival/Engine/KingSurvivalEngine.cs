namespace KingSurvival.Engine
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using KingSurvival.Engine.Contracts;
    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Figures;
    using KingSurvival.Renderers.Contracts;
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


            // players=new List<IPlayer>();
        }

        public void Initialize()
        {
            //TODO:Extract to another class and interface
            this.players = provider.GetPlayers(Constants.StandardNumberOfPlayers);

            Validator.ValidateGameInitialization(this.players, this.board);

            var firstPlayer = players[0];
            IFiguresFactory figures = new FiguresFactory();
            IFigure king = figures.CreateKing();
            IList<IFigure> pawns = figures.CreatePawns();

            firstPlayer.AddFigure(king);
            this.board.AddFigure(king, king.Position);

            var secondPlayer = players[1];

            for (var i = 0; i < pawns.Count; i++)
            {
                secondPlayer.AddFigure(pawns[i]);
                this.board.AddFigure(pawns[i], pawns[i].Position);
            }
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

                    Move move = this.provider.GetNextMoveFigure(player);
                    var from = move.From;
                    var to = move.To;
                    Position.CheckIfValid(to, GlobalErrorMessages.PositionNotValidMessage);

                    var figure = this.board.GetFigureAtPosition(from);
                    this.board.RemoveFigure(figure, from);
                    figure.Position = new Position(to.Row, to.Col);
                    this.board.AddFigure(figure, to);

                    this.renderer.RenderBoard(this.board);

                    if (WinningConditions(player))
                    {
                        this.renderer.PrintErrorMessage("The king won");
                        return;
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
                if (this.players[i].Color == ChessColor.K)
                {
                    this.currentPlayerIndex = i;
                    return;
                }
            }
        }

        public bool WinningConditions(IPlayer player)
        {
            if (KingWon(player))
            {
                return true;
            }
            return false;
            //TODO:Add more conditions

        }
        public bool KingWon(IPlayer player)
        {
            if (player.Figures[0].Color == ChessColor.K)
            {
                if (player.Figures[0].Position.Row == 0) //check if king is on the first row
                {
                    return true;
                }
            }

            return false;
            //TODO:Add the rest of the conditions
        }

    }
}
