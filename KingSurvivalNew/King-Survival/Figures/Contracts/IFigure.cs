namespace KingSurvival.Figures.Contracts
{
    using KingSurvival.Common;
    using KingSurvival.Players.Contracts;

    public interface IFigure
    {
        FigureSign Sign { get; }

        Position Position { get; set; }

    }
}


