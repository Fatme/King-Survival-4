namespace KingSurvival.Figures
{
    using KingSurvival.Commands;
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Figures.Contracts;

    public abstract class Figure : IFigure,IContentProvider
    {
        protected Figure(FigureSign sign)
        {
            this.Sign = sign;
        }

        public FigureSign Sign { get; private set; }

        public string ProvideContent()
        {
            return this.Sign.ToString();
        }

    }
}
