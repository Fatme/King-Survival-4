namespace KingSurvival.FigureFactory.Contracts
{
    using KingSurvival.Common;

    using KingSurvival.Figures.Contracts;

    interface IFigureFactory
    {
        IFigure CreateFigure();
    }
}
