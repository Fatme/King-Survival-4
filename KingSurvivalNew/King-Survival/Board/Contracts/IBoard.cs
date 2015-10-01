using KingSurvival.Commands.Contracts;

namespace KingSurvival.Board.Contracts
{
    using KingSurvival.Commands;
    using KingSurvival.Figures.Contracts;

    public interface IBoard
    {
        int NumberOfRows { get; }

        int NumberOfColumns { get; }
       
        void AddFigure(IFigure figure,IPosition position);

        IFigure GetFigureAtPosition(IPosition position);

        void RemoveFigure(IFigure figure,IPosition position);

        IPosition GetFigurePosition(IFigure figure);

    }
}
