using KingSurvival.Common;

namespace KingSurvival.FigureFactory.Contracts
{
    using KingSurvival.Figures.Contracts;

    interface IFigureFactory
    {
        IFigure CreateFigure(FigureSign sign);
    }
}
