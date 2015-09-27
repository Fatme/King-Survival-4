namespace KingSurvival.Figures
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;

    public class King : Figure, IFigure
    {
        public King(FigureSign sign)
            : base(sign)
        {
        }
    }
}
