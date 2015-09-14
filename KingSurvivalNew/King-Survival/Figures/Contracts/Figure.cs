namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;
    public abstract class Figure : IFigure
    {
        protected Figure(ChessColor color,Position position)
        {
            this.Color = color;
            this.Position = position;
        }

        public ChessColor Color { get; private set; }

        public Position Position { get; private set; }

        
    }
}
