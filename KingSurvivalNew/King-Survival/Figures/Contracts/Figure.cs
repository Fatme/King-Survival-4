namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;
    public abstract class Figure : IFigure
    {
        private Position position;
        protected Figure(ChessColor color, Position position)
        {
            this.Color = color;
            this.Position = position;
        }

        public ChessColor Color { get; private set; }

        public Position Position
        {
            get { return this.position; }
            set { this.position = value; }
        }


    }
}
