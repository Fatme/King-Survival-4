namespace KingSurvival.FigureFactory
{
    using KingSurvival.Common;
    using KingSurvival.FigureFactory.Contracts;
    using KingSurvival.Figures;
    using KingSurvival.Figures.Contracts;

    public class PawnFigureFactory : IFigureFactory
    {
        public IFigure CreateFigure(FigureSign sign)
        {
            IFigure pawn = new Pawn(sign);
            return pawn;
        }
    }
}
