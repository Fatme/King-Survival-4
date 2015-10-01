namespace KingSurvival.Board.Contracts
{
    using KingSurvival.Common;
    using KingSurvival.Figures.Contracts;

    public interface IBoard
    {
        int NumberOfRows { get; }

        int NumberOfColumns { get; }
       
        void AddFigure(IFigure figure,Position position);

        IFigure GetFigureAtPosition(Position position);

        void RemoveFigure(IFigure figure,Position position);

        Position GetFigurePosition(IFigure figure);

    }
}
