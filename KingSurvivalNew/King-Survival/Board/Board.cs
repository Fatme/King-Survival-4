using KingSurvival.Common.Contracts;

namespace KingSurvival.Board
{
    using System.Collections.Generic;

    using KingSurvival.Board.Contracts;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;
    
    public class Board : IBoard
    {
        private IFigure[,] board;
        private readonly Dictionary<IFigure, Position> FigurePositionsOnBoard = new Dictionary<IFigure, Position>();

        public Board(int rows=Constants.StandardChessRows, int columns=Constants.StandardChessColumns)
        {
            this.NumberOfColumns = columns;
            this.NumberOfRows = rows;
            this.board = new IFigure[rows, columns];
        }

        public int NumberOfRows { get; private set; }

        public int NumberOfColumns { get; private set; }


        public void AddFigure(IFigure figure,Position position)
        {
            Validator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            Validator.CheckIfPositionValid(position,GlobalErrorMessages.PositionNotValidMessage);            
            this.board[position.Row, position.Col] = figure;

            this.FigurePositionsOnBoard[figure] = position;

        }

        public IFigure GetFigureAtPosition(Position position)
        {
            return this.board[position.Row, position.Col];
        }
      
        public void RemoveFigure(IFigure figure,Position position)
        {
            Validator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            Validator.CheckIfPositionValid(position,GlobalErrorMessages.PositionNotValidMessage);
            this.board[position.Row, position.Col] = null;
        }

        public Position GetFigurePosition(IFigure figure)
        {
            Position position;
            this.FigurePositionsOnBoard.TryGetValue(figure, out position);
            return position;
        }
    }
}
