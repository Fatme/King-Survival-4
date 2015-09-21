namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Common;

    public abstract class Figure : IFigure
    {
        private Position position;

        protected Figure(FigureSign sign, Position position)
        {
           
            this.Position = position;
            this.Sign = sign;
        }

        public FigureSign Sign { get; private set; }

        public Position Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

    }
}
