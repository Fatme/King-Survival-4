namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Common;

    public interface IFigure
    {
        FigureSign Sign { get; }

        Position Position { get; set; }

    }
}


