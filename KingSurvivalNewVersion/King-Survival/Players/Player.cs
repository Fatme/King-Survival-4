using KingSurvival.Commands.Contracts;

namespace KingSurvival.Players
{
    using System.Collections.Generic;

    using KingSurvival.Players.Contracts;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common.Contracts;

    public  class Player : IPlayer
    {


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

        public Move GenerateNewMove(Position oldPosition, int direction)
        {
            int[] deltaRow = { -1, +1, +1, -1 }; //UR, DR, DL, UL
            int[] deltaCol = { +1, +1, -1, -1 };
            int newRow = oldPosition.Row + deltaRow[direction];
            int newColumn = oldPosition.Col + deltaCol[direction];
            var newPosition = new Position(newRow, newColumn);
            return new Move(oldPosition, newPosition);
        }
    }
}
