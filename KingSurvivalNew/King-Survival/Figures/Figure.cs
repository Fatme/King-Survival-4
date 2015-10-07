namespace KingSurvival.Figures
{
    using KingSurvival.Common;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Figures.Contracts;

    public class Figure : IFigure, IFigurePrototype
    {
        public Figure(FigureSign sign)
        {
            this.Sign = sign;
        }

        public Figure()
        {
        }

        public FigureSign Sign { get; private set; }

        public void AddSign(FigureSign sign)
        {
            this.Sign = sign;
        }

        public IFigure Clone()
        {
            return (IFigure)this.MemberwiseClone();
        }
    }
}
