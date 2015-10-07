namespace KingSurvival.Board.Contracts
{
    using KingSurvival.Common.Contracts;
    using KingSurvival.Figures.Contracts;

    public interface IBoard : IMemorizable
    {
        int NumberOfRows { get; }

        int NumberOfColumns { get; }

        void AddFigure(IFigure figure, IPosition position);

        IFigure GetFigureAtPosition(IPosition position);

        void RemoveFigure(IFigure figure, IPosition position);

        IPosition GetFigurePosition(IFigure figure);
    }
}
