﻿namespace KingSurvival.Players
{
    using System.Collections.Generic;

    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Commands;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Commands.Contracts;
  
    public abstract class Player : IPlayer
    {
        private static int[] deltaRow = { -1, +1, +1, -1 }; //UR, DR, DL, UL
        private static int[] deltaCol = { +1, +1, -1, -1 };

        private IList<IFigure> figures;

        public string Name { get; private set; }

        public IList<IFigure> Figures
        {
            get { return this.figures; }
        }

        public Player(string name)
        {            
            this.Name = name;
            this.figures = new List<IFigure>();
        }

        public void AddFigure(IFigure figure)
        {
           this.figures.Add(figure);
        }

        public abstract IDictionary<string, int> MapCommandToDirection
        {
            get;
        }

        public abstract Move Move(ICommand command, IBoard board);

        protected Move GenerateNewMove(IPosition oldPosition, int direction)
        {
            int newRow = oldPosition.Row + Player.deltaRow[direction];
            int newColumn = oldPosition.Col + Player.deltaCol[direction];
            var newPosition = new Position(newRow, newColumn);
            return new Move(oldPosition, newPosition);
        }
    }
}
