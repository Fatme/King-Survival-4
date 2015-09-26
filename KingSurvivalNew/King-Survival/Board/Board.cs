using System;
using System.Collections.Generic;

namespace KingSurvival.Board
{
    using KingSurvival.Board.Contracts;
    using KingSurvival.Figures.Contracts;
    using KingSurvival.Common;
    
    public class Board : IBoard
    {
        private IFigure[,] board;
        private Dictionary<IFigure, Position> figurePositionsOnBoard = new Dictionary<IFigure, Position>();

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
            Position.CheckIfValid(position,GlobalErrorMessages.PositionNotValidMessage);            
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

        public IFigure GetFigureAtPosition(Position position)
        {
            return this.board[position.Row, position.Col];
        }

        public void RemoveFigure(IFigure figure,Position position)
        {
            Validator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            Position.CheckIfValid(position,GlobalErrorMessages.PositionNotValidMessage);
            this.board[position.Row, position.Col] = null;
        }

        public Position GetFigurePosition(IFigure figure)
        {
            Position position;
            figurePositionsOnBoard.TryGetValue(figure, out position);
            return position;
        }
    }
}
