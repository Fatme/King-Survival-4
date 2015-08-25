using System;

namespace KingSurvival.Board
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;

    public class Board : IBoard
    {
        private IFigure[,] board;

        public Board(int rows=Constants.StandardChessRows, int columns=Constants.StandarsChessColumns)
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
            this.CheckIfPositionIsValid(position);
            
            this.board[position.Row, position.Col] = figure;
            //the logic for adding figure
        }

        private int GetArrayRow(int chessRow)
        {
            return this.NumberOfRows - chessRow;
        }

        private int GetArrayCol(char chessCol)
        {
            return chessCol - 'a';
        }

        private void CheckIfPositionIsValid(Position position)
        {
            if (position.Row < Constants.MinimumRowValueOnBoard
                || position.Row > Constants.MaximumRowValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected row position on the board is not valid!");
            }

            if (position.Col < Constants.MinimumColumnValueOnBoard
                || position.Col > Constants.MaximumColumnValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected column position on the board is not valid!");
            }
        }
        public IFigure GetFigureAtPosition(Position position)
        {
            return this.board[position.Row, position.Col];
        }

        
    }
}
