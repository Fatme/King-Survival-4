namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;
    public abstract class Figure : IFigure
    {
        protected Figure(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }

        
    }
}
