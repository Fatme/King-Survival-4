﻿namespace KingSurvival.Commands
{
    using System;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Commands.Contracts;
    using KingSurvival.Common;
    using System.Collections.Generic;
    using KingSurvival.Board.Contracts;

    public abstract class MoveCommand:ICommand,IPlayerCommand
    {
       // protected ICommandContext context;

        public MoveCommand(int figureIndex,int direction)
        {
           // this.context = context;
            this.FigureIndex = figureIndex;
            this.Direction = direction;
        }

        public int FigureIndex { get; private set; }

        public int Direction { get; private set; }

        public virtual void Execute(ICommandContext context)
        {
            context.Memory.Memento = context.Board.SaveMemento();
            var from = context.Board.GetFigurePosition(context.Player.Figures[this.FigureIndex]);
            IPosition to = this.GenerateNewPosition(from, this.Direction);
            Validator.CheckIfPositionValid(to, GlobalErrorMessages.PositionNotValidMessage);
            Validator.CheckIfFigureOnTheWay(to, context.Board, GlobalErrorMessages.FigureOnTheWayErrorMessage);

            var figure = context.Board.GetFigureAtPosition(from);

            context.Board.RemoveFigure(figure, from);
            context.Board.AddFigure(figure, to);
        }
        private IPosition GenerateNewPosition(IPosition oldPosition, int direction)
        {
            int[] deltaRow = { -1, +1, +1, -1 }; //UR, DR, DL, UL
            int[] deltaCol = { +1, +1, -1, -1 };
            int newRow = oldPosition.Row + deltaRow[direction];
            int newColumn = oldPosition.Col + deltaCol[direction];
            var newPosition = new Position(newRow, newColumn);
            return newPosition;
        }
        
        public  abstract string Name { get; }
    }
}
