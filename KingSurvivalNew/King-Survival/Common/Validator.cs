namespace KingSurvival.Common
{
    using System;
    using System.Collections.Generic;

    using KingSurvival.Board.Contracts;
    using KingSurvival.Common.Contracts;
    using KingSurvival.Players.Contracts;

    public static class Validator
    {
        public static void CheckIfObjectIsNull(object obj, string errorMessage)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(errorMessage);
            }
        }

        public static void ValidateGameInitialization(IList<IPlayer> players, IBoard board)
        {
            if (players.Count != Constants.StandardNumberOfPlayers)
            {
                throw new InvalidOperationException("King Survival Engine must have two player");
            }

            if (board.NumberOfRows != Constants.StandardChessRows || board.NumberOfColumns != Constants.StandardChessColumns)
            {
                throw new InvalidOperationException("King survial has 8x8 board");
            }
        }

        public static void CheckIfFigureOnTheWay(IPosition position, IBoard board, string message)
        {
            if (board.GetFigureAtPosition(position) != null)
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfPositionValid(IPosition position, string errorMessage)
        {
            if (position.Row < Constants.MinimumRowValueOnBoard
                || position.Row > Constants.MaximumRowValueOnBoard)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }

            if (position.Col < Constants.MinimumColumnValueOnBoard
                || position.Col > Constants.MaximumColumnValueOnBoard)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }
        }
    }
}
