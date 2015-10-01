﻿namespace KingSurvival.Engine
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
    using FigureFactory.Contracts;

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


        public KingSurvivalEngine(IRenderer renderer, IInputProvider inputProvider, IBoard board, IWinningConditions winningConditions)
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
            var firstPlayer = players[0];
            var secondPlayer = players[1];

            var figureFactory = new FigureFactory();
            IFigure figure = figureFactory.CreateFigure();

            var king = figure.Clone();
            king.AddSign(FigureSign.K);
            firstPlayer.AddFigure(king);
            this.board.AddFigure(king, new Position(Constants.InitialKingRow, Constants.InitialKingColumn));


            var pawnA = figure.Clone();
            pawnA.AddSign(FigureSign.A);
            secondPlayer.AddFigure(pawnA);
            this.board.AddFigure(pawnA, new Position(Constants.PawnAInitialRow, Constants.PawnAInitialCol));

            var pawnB = figure.Clone();
            pawnB.AddSign(FigureSign.B);
            secondPlayer.AddFigure(pawnB);
            this.board.AddFigure(pawnB, new Position(Constants.PawnBInitialRow, Constants.PawnBInitialCol));
           
            var pawnC = figure.Clone();
            pawnC.AddSign(FigureSign.C);
            secondPlayer.AddFigure(pawnC);
            this.board.AddFigure(pawnC, new Position(Constants.PawnCInitialRow, Constants.PawnCInitialCol));
            
            var pawnD = figure.Clone();
            pawnD.AddSign(FigureSign.D);
            secondPlayer.AddFigure(pawnD);
            this.board.AddFigure(pawnD, new Position(Constants.PawnDInitialRow, Constants.PawnDInitialCol));






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
                        this.renderer.PrintMessage("The king won");
                        break;
                    }

                    if (this.winningConditions.KingLost(this.players, this.board))
                    {
                        this.renderer.PrintMessage("The king lost");
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
    }
}
