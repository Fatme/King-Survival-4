namespace KingSurvival.Commands
{
    using System;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Common;
    using System.Collections.Generic;
    using KingSurvival.Board.Contracts;
    using KingSurvival.Figures.Contracts;

    public abstract class PlayerCommand
    {
        private IBoard board;

        public PlayerCommand(IBoard board)
        {
            this.board = board;
        }

        public abstract int Direction
        {
            get;
        }

        public abstract int FigureIndex
        {
            get;
        }

        public void Execute(IList<IFigure> figures)
        {
            var oldPosition = this.board.GetFigurePosition(figures[this.FigureIndex]);
            Move move = this.GenerateNewMove(oldPosition, this.Direction);

            var from = move.From;
            var to = move.To;

            Validator.CheckIfPositionValid(to, GlobalErrorMessages.PositionNotValidMessage);
            Validator.CheckIfFigureOnTheWay(to, this.board, GlobalErrorMessages.FigureOnTheWayErrorMessage);

            var figure = this.board.GetFigureAtPosition(from);

            this.board.RemoveFigure(figure, from);
            this.board.AddFigure(figure, to);
        }

        private Move GenerateNewMove(Position oldPosition, int direction)
        {
            int[] deltaRow = { -1, +1, +1, -1 }; //UR, DR, DL, UL
            int[] deltaCol = { +1, +1, -1, -1 };
            int newRow = oldPosition.Row + deltaRow[direction];
            int newColumn = oldPosition.Col + deltaCol[direction];
            var newPosition = new Position(newRow, newColumn);
            return new Move(oldPosition, newPosition);
        }
    }
}
