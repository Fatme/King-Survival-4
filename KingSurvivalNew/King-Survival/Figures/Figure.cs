namespace KingSurvival.Figures
{
    using KingSurvival.Common;
    using KingSurvival.Figures.Contracts;

    public abstract class Figure : IFigure
    {
        protected Figure(FigureSign sign)
        {
            this.Sign = sign;
        }

        public FigureSign Sign { get; private set; }
    }
}
