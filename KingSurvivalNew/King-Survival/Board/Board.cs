using KingSurvival.Commands.Contracts;

namespace KingSurvival.Board
{
    using System.Collections.Generic;

    using KingSurvival.Board.Contracts;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Commands;
    
    public class Board : IBoard
    {
        private IFigure[,] board;
        private Dictionary<IFigure, IPosition> figurePositionsOnBoard = new Dictionary<IFigure,IPosition>();

        public Board(int rows=Constants.StandardChessRows, int columns=Constants.StandardChessColumns)
        {
            this.NumberOfColumns = columns;
            this.NumberOfRows = rows;
            this.board = new IFigure[rows, columns];
        }

        public int NumberOfRows { get; private set; }

        public int NumberOfColumns { get; private set; }


        public void AddFigure(IFigure figure,IPosition position)
        {
            Validator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            Validator.CheckIfPositionValid(position,GlobalErrorMessages.PositionNotValidMessage);            
            this.board[position.Row, position.Col] = figure;

            this.figurePositionsOnBoard[figure] = position;

        }

        //private int GetArrayRow(int chessRow)
        //{
        //    return this.NumberOfRows - chessRow;
        //}

        //private int GetArrayCol(char chessCol)
        //{
        //    return chessCol - 'a';
        //}

        public IFigure GetFigureAtPosition(IPosition position)
        {
            return this.board[position.Row, position.Col];
        }

      
        public void RemoveFigure(IFigure figure,IPosition position)
        {
            Validator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            Validator.CheckIfPositionValid(position,GlobalErrorMessages.PositionNotValidMessage);
            this.board[position.Row, position.Col] = null;
        }

        public IPosition GetFigurePosition(IFigure figure)
        {
            IPosition position;
            figurePositionsOnBoard.TryGetValue(figure, out position);
            return position;
        }
    }
}
