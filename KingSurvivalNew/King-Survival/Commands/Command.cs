namespace KingSurvival.Commands
{
    using System;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Common;
    using System.Collections.Generic;
    using KingSurvival.Board.Contracts;

    public class Command
    {
        private IBoard board;

        public Command(IBoard board)
        {
            this.board = board;
        }

        public void Execute(Move move)
        {
            var from = move.From;
            var to = move.To;

            Validator.CheckIfPositionValid(to, GlobalErrorMessages.PositionNotValidMessage);
            Validator.CheckIfFigureOnTheWay(to, this.board, GlobalErrorMessages.FigureOnTheWayErrorMessage);

            var figure = this.board.GetFigureAtPosition(from);

            this.board.RemoveFigure(figure, from);
            this.board.AddFigure(figure, to);
        }
    }
}
