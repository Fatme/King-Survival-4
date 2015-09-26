namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;
    public abstract class Figure : IFigure
    {

        protected Figure(FigureSign sign)
        {
           
            
            this.Sign = sign;
        }

        public FigureSign Sign { get; private set; }


    }
}
