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
    }
}
