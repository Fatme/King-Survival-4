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
            Position.CheckIfValid(position);
            
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

        public IFigure GetFigureAtPosition(Position position)
        {
            return this.board[position.Row, position.Col];
        }

        
    }
}
