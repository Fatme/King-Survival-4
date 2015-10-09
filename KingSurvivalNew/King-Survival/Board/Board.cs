namespace KingSurvival.Board
{
    using System.Collections.Generic;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Figures.Contracts;

    public class Board : IBoard, IMemorizable
    {
        private IFigure[,] board;
        private Dictionary<string, IPosition> figurePositionsOnBoard = new Dictionary<string, IPosition>();

        public Board(int rows = Constants.StandardBoardRows, int columns = Constants.StandardBoardColumns)
        {
            this.NumberOfColumns = columns;
            this.NumberOfRows = rows;
            this.board = new IFigure[rows, columns];
        }

        public int NumberOfRows { get; private set; }

        public int NumberOfColumns { get; private set; }

        public void AddFigure(IFigure figure, IPosition position)
        {
            Validator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            Validator.CheckIfPositionValid(position, GlobalErrorMessages.PositionNotValidMessage);
            this.board[position.Row, position.Col] = figure;
            this.figurePositionsOnBoard[figure.DisplayName] = position;
        }

        public IFigure GetFigureAtPosition(IPosition position)
        {           
            return this.board[position.Row, position.Col];
        }

        public void RemoveFigure(IFigure figure, IPosition position)
        {
            Validator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            Validator.CheckIfPositionValid(position, GlobalErrorMessages.PositionNotValidMessage);
            this.board[position.Row, position.Col] = null;
        }

        public IPosition GetFigurePosition(IFigure figure)
        {
            IPosition position;
            this.figurePositionsOnBoard.TryGetValue(figure.DisplayName, out position);
            return position;
        }

        public Memento SaveMemento()
        {
            Dictionary<string, IPosition> copiedFigurePositionsOnBoard = new Dictionary<string, IPosition>();

            foreach (var pair in this.figurePositionsOnBoard)
            {
                copiedFigurePositionsOnBoard.Add(pair.Key, new Position(pair.Value.Row, pair.Value.Col));
            }

            return new Memento(this.board, copiedFigurePositionsOnBoard);
        }

        public void RestoreMemento(Memento memento)
        {
            this.board = memento.Board;
            this.figurePositionsOnBoard = memento.FigurePositionsOnBoard;
        }
    }
}
