namespace KingSurvival.Figures
{
    using KingSurvival.Figures.Contracts;

    public abstract class Figure:IFigure,IFigurePrototype
    {
        public string ProvideFigureShape()
        {
            return this.ProvideShape();
        }

        protected abstract string ProvideShape();

        public IFigure Clone()
        {
            return (IFigure)this.MemberwiseClone();
        }
    }
}
