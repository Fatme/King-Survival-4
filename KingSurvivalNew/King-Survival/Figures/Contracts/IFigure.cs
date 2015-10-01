namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;

    public interface IFigure : IFigurePrototype
    {
        FigureSign Sign { get; }

        void AddSign(FigureSign sign);

    }
}


