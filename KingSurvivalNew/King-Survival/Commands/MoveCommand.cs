using System;

namespace KingSurvival.Commands
{
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Common;
    using KingSurvival.Common.Contracts;

    public abstract class MoveCommand : Command, ICommand, IMoveCommand
    {
        protected MoveCommand(int figureIndex, int direction)
        {
            this.FigureIndex = figureIndex;
            this.Direction = direction;
        }

        public int FigureIndex { get; private set; }

        public int Direction { get; private set; }

        public override void Execute(ICommandContext context, string commandName)
        {
            // this.CheckIfCommandIsCorrect(commandName);
            context.Memory.Memento = context.Board.SaveMemento();

            var figureToMove = context.Player.Figures[this.FigureIndex];
            figureToMove.CheckIfCommandIsValid(commandName);
            IPosition from = context.Board.GetFigurePosition(context.Player.Figures[this.FigureIndex]);
            IPosition to = this.GenerateNewPosition(from, this.Direction);

            Validator.CheckIfPositionValid(to, GlobalErrorMessages.PositionNotValidMessage);
            Validator.CheckIfFigureOnTheWay(to, context.Board, GlobalErrorMessages.FigureOnTheWayErrorMessage);

            var figure = context.Board.GetFigureAtPosition(from);

            context.Board.RemoveFigure(figure, from);
            context.Board.AddFigure(figure, to);
            context.Player.MovesCount++;
        }

        private IPosition GenerateNewPosition(IPosition oldPosition, int direction)
        {
            int[] deltaRow = { -1, +1, +1, -1 }; ////UR, DR, DL, UL
            int[] deltaCol = { +1, +1, -1, -1 };
            int newRow = oldPosition.Row + deltaRow[direction];
            int newColumn = oldPosition.Col + deltaCol[direction];
            var newPosition = new Position(newRow, newColumn);
            return newPosition;
        }
    }
}
