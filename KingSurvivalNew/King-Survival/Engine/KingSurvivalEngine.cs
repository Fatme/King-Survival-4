﻿namespace KingSurvival.Engine
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




        public IEnumerable<IPlayer> Players
        {
            get { throw new NotImplementedException(); }
        }

        public void Initialize()
        {
            //TODO:Extract to another class and interface
            this.players = provider.GetPlayers(Constants.StandardNumberOfPlayers);

            this.ValidateGameInitialization();

            var firstPlayer = players[0];
            var secondPlayer = players[1];
            int positionColPawn = 0;
            for (var i = 0; i < Constants.numberOfPawns; i++)
            {
                var positionPawn = new Position(0, positionColPawn);
                var pawn = new Pawn((ChessColor)(i + 2),positionPawn);
                firstPlayer.AddFigure(pawn);
                this.board.AddFigure(pawn, positionPawn);
                positionColPawn += 2;
            }
            this.SetFirstPlayerIndex();
            var positionKing = new Position(7, 3);
            var king = new King(ChessColor.K,positionKing);
         
            secondPlayer.AddFigure(king);
            this.board.AddFigure(king, positionKing);
            this.renderer.RenderBoard(this.board);
        }


        private void ValidateGameInitialization()
        {
            if (this.players.Count != Constants.StandardNumberOfPlayers)
            {
                throw new InvalidOperationException("King Survival Engine must have two player");
            }

            if (this.board.NumberOfRows != BoardTotalNUmberOfRows || this.board.NumberOfColumns != BoardTotalNUmberOfColumns)
            {
                throw new InvalidOperationException("King survial has 8x8 board");
            }
        }
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
                    var figure=this.board.GetFigureAtPosition(from);
                    this.board.AddFigure(figure,to);
                    this.renderer.RenderBoard(this.board);
                }
                catch (Exception ex)
                {
                    //TODO:MAke a good error
                    this.renderer.PrintErrorMessage("Erroorr");
                }
            }




        }

        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;
            if (currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }
         
            return this.players[this.currentPlayerIndex];
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

        public void WinningConditions()
        {
            throw new NotImplementedException();
        }

    }
}
