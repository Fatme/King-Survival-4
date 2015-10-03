using KingSurvival.Common.Contracts;

namespace KingSurvival.Board
{
    using System.Collections.Generic;

    using KingSurvival.Board.Contracts;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;

    public class Board : IBoard, IMemorizable
    {
        private IFigure[,] board;
        private Dictionary<IFigure, Position> figurePositionsOnBoard = new Dictionary<IFigure, Position>();

        public Board(int rows = Constants.StandardChessRows, int columns = Constants.StandardChessColumns)
        {
            this.NumberOfColumns = columns;
            this.NumberOfRows = rows;
            this.board = new IFigure[rows, columns];
        }

        public int NumberOfRows { get; private set; }

        public int NumberOfColumns { get; private set; }




        public void AddFigure(IFigure figure, Position position)
        {
            Validator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            Validator.CheckIfPositionValid(position, GlobalErrorMessages.PositionNotValidMessage);
            this.board[position.Row, position.Col] = figure;

            this.figurePositionsOnBoard[figure] = position;

        }

        public IFigure GetFigureAtPosition(Position position)
        {
            return this.board[position.Row, position.Col];
        }

        public void RemoveFigure(IFigure figure, Position position)
        {
            Validator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            Validator.CheckIfPositionValid(position, GlobalErrorMessages.PositionNotValidMessage);
            this.board[position.Row, position.Col] = null;
        }

        public Position GetFigurePosition(IFigure figure)
        {
            Position position;
            this.figurePositionsOnBoard.TryGetValue(figure, out position);
            return position;
        }

        public Memento SaveMemento()
        {
            return new Memento(this.board, this.figurePositionsOnBoard);
        }

        public void RestoreMemento(Memento memento)
        {
            this.board = memento.Board;
            this.figurePositionsOnBoard = memento.FigurePositionsOnBoard;
            
        }
       
    }
}
