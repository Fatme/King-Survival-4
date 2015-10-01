namespace KingSurvival.FigureFactory.Contracts
{
    using KingSurvival.Commands;

    using KingSurvival.Figures.Contracts;

    interface IFigureFactory
    {
        IFigure CreateFigure(FigureSign sign);
    }
}
